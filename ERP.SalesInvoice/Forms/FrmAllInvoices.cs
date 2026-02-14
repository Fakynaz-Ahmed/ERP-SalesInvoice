using ERP.SalesInvoice.Data;
using ERP.SalesInvoice.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace ERP.SalesInvoice.Forms
{
    public partial class FrmAllInvoices : Form
    {
        private AppDbContext _context;
        private readonly IServiceProvider _serviceProvider;
        public FrmAllInvoices(AppDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void FrmAllInvoices_Load(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        private void LoadInvoices()
        {
            dgvInvoices.AutoGenerateColumns = false;
            dgvInvoices.Columns.Clear();

            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Invoice #",
                DataPropertyName = "InvoiceNumber",
                ReadOnly = true
            });

            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Date",
                DataPropertyName = "InvoiceDate",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvInvoices.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "TotalAmount",
                DataPropertyName = "TotalAmount",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "0.00" }
            });

            dgvInvoices.DataSource = _context.Invoices.ToList();
        }
      
        private void btnNewInvoice_Click(object sender, EventArgs e)
        {

            using (var scope = _serviceProvider.CreateScope())
            {
                var frm = scope.ServiceProvider.GetRequiredService<FrmInvoice>();
                frm.ShowDialog();
            }
            LoadInvoices();
        }

        private void btnEditInvoice_Click(object sender, EventArgs e)
        {
            var selectedInvoice = dgvInvoices.CurrentRow?.DataBoundItem as Invoice;
            if (selectedInvoice == null)
            {
                MessageBox.Show("Please select an invoice to edit.");
                return;
            }
            using (var scope = _serviceProvider.CreateScope())
            {
                var frm = scope.ServiceProvider.GetRequiredService<FrmInvoice>();
                frm.LoadInvoiceForEdit(selectedInvoice.Id);
                frm.ShowDialog();
            }
            _context.ChangeTracker.Clear();
            LoadInvoices();
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            var selectedInvoice = dgvInvoices.CurrentRow?.DataBoundItem as Invoice;
            if (selectedInvoice == null)
            {
                MessageBox.Show("Please select an invoice to delete.");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this invoice?",
                "Confirm Delete", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            var details = _context.InvoiceDetails.Where(d => d.InvoiceId == selectedInvoice.Id).ToList();
            _context.InvoiceDetails.RemoveRange(details);

            _context.Invoices.Remove(selectedInvoice);
            _context.SaveChanges();

            MessageBox.Show("Invoice deleted successfully.");
            _context.ChangeTracker.Clear();
            LoadInvoices(); 
        }

    }
}
