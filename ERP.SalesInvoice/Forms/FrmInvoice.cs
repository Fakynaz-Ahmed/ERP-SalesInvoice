using ERP.SalesInvoice.Data;
using ERP.SalesInvoice.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ERP.SalesInvoice
{
    public partial class FrmInvoice : Form
    {
        private AppDbContext _context;
        private BindingList<InvoiceDetail> _invoiceDetails = new BindingList<InvoiceDetail>();
        private int _currentInvoiceId = 0;
        private bool _isEditMode = false;

        public FrmInvoice(AppDbContext context)
        {
            _context = context;
            InitializeComponent();
        }

        private void FrmInvoice_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadItems();
            if (!_isEditMode)
                GenerateNewInvoice();
            LoadInvoiceDetails();
        }

        private void LoadInvoiceDetails()
        {
            dgvItems.AutoGenerateColumns = false;
            dgvItems.Columns.Clear();

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Item",
                DataPropertyName = "ItemName",
                ReadOnly = true
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Quantity",
                DataPropertyName = "Quantity"
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Price",
                DataPropertyName = "Price",
                ReadOnly = true
            });

            dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total",
                DataPropertyName = "Total",
                ReadOnly = true
            });

            dgvItems.DataSource = _invoiceDetails;
        }

        private void LoadCustomers()
        {
            var customers = _context.Customers.ToList();
            if (customers.Any())
            {
                cmbCustomer.DataSource = customers;
                cmbCustomer.DisplayMember = "Name";
                cmbCustomer.ValueMember = "Id";
            }
        }

        private void LoadItems()
        {
            var items = _context.Items.ToList();
            if (items.Any())
            {
                cmbItem.DataSource = items;
                cmbItem.DisplayMember = "Name";
                cmbItem.ValueMember = "Id";
            }
           
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
          
            if (cmbItem.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item");
                return;
            }

            int itemId = (int)cmbItem.SelectedValue;
            var item = _context.Items.Find(itemId);

            if (item == null) return;

            int qty = (int)numQuantity.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero");
                return;
            }

            var existingDetail = _invoiceDetails.FirstOrDefault(d => d.ItemId == item.Id);
            if (existingDetail != null)
            {
                existingDetail.Quantity += qty;
                dgvItems.Refresh(); 
            }
            else
            {
                var detail = new InvoiceDetail
                {
                    ItemId = item.Id,
                    Item = item,
                    Quantity = qty,
                    Price = item.Price
                };
                _invoiceDetails.Add(detail);
                dgvItems.Refresh();
            }

            CalculateTotal();
        }      

        private void CalculateTotal()
        {
            decimal total = _invoiceDetails.Sum(x => x.Total);
            txtInvoiceTotal.Text = total.ToString("0.00");
        }

        private void GenerateNewInvoice()
        {
            txtInvoiceNumber.Text = GenerateInvoiceNumber();
            dtpInvoiceDate.Value = DateTime.Now;
            _invoiceDetails.Clear();
            txtInvoiceTotal.Text = "0.00";
        }

        private string GenerateInvoiceNumber()
        {
            int lastId = _context.Invoices.Any() ? _context.Invoices.Max(i => i.Id) : 0;
            return $"INV-{lastId + 1:0000}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isEditMode)
                    UpdateInvoice();
                
                else
                    CreateInvoice();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        private void UpdateInvoice()
        {
            try
            {
                var invoice = _context.Invoices
                .Include(i => i.InvoiceDetails)
                .FirstOrDefault(i => i.Id == _currentInvoiceId);

                if (invoice == null) return;

                invoice.CustomerId = (int)cmbCustomer.SelectedValue;
                invoice.InvoiceDate = dtpInvoiceDate.Value;
                invoice.TotalAmount = _invoiceDetails.Sum(d => d.Total);

                _context.InvoiceDetails.RemoveRange(invoice.InvoiceDetails);
                invoice.InvoiceDetails.Clear();
                foreach (var detail in _invoiceDetails)
                {
                    invoice.InvoiceDetails.Add(new InvoiceDetail
                    {
                        ItemId = detail.ItemId,
                        Quantity = detail.Quantity,
                        Price = detail.Price
                    });
                }

                _context.SaveChanges();

                MessageBox.Show("Invoice updated successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the invoice: {ex.Message}");
            }
        }
        private void CreateInvoice()
        {
            try
            {
                if (cmbCustomer.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a customer");
                    return;
                }

                if (_invoiceDetails.Count == 0)
                {
                    MessageBox.Show("Please add at least one item");
                    return;
                }

                foreach (var item in _invoiceDetails)
                {
                    if (item.Quantity <= 0)
                    {
                        MessageBox.Show($"Quantity for {item.Item.Name} must be greater than zero");
                        return;
                    }
                }

                var invoice = new Invoice
                {
                    InvoiceNumber = txtInvoiceNumber.Text,
                    InvoiceDate = dtpInvoiceDate.Value,
                    CustomerId = (int)cmbCustomer.SelectedValue,
                    TotalAmount = _invoiceDetails.Sum(x => x.Total),
                    InvoiceDetails = _invoiceDetails.ToList()
                };

                _context.Invoices.Add(invoice);
                _context.SaveChanges();

                MessageBox.Show("Invoice Saved Successfully");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the invoice: {ex.Message}");
            }
        }

        public void LoadInvoiceForEdit(int invoiceId)
        {   
            _isEditMode = true;    
            _currentInvoiceId = invoiceId;
            var invoice = _context.Invoices
                .Include(i => i.InvoiceDetails)
                .ThenInclude(d => d.Item)
                .FirstOrDefault(i => i.Id == invoiceId);

            if (invoice == null) return;

            txtInvoiceNumber.Text = invoice.InvoiceNumber;
            dtpInvoiceDate.Value = invoice.InvoiceDate;
            cmbCustomer.SelectedValue = invoice.CustomerId;

            _invoiceDetails.Clear();
            foreach (var detail in invoice.InvoiceDetails)
            {
                _invoiceDetails.Add(detail);
            }

            CalculateTotal();
        }       

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
 
    }
}
