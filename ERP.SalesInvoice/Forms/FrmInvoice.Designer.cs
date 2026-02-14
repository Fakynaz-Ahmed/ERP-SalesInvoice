namespace ERP.SalesInvoice
{
    partial class FrmInvoice
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtInvoiceNumber = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbCustomer = new ComboBox();
            btnInvoiceSave = new Button();
            btnCancel = new Button();
            label5 = new Label();
            cmbItem = new ComboBox();
            label7 = new Label();
            dgvItems = new DataGridView();
            ItemName = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            Delete = new DataGridViewButtonColumn();
            label8 = new Label();
            txtInvoiceTotal = new TextBox();
            numQuantity = new NumericUpDown();
            dtpInvoiceDate = new DateTimePicker();
            btnAddItem = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(567, 40);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "Invoice #";
            // 
            // txtInvoiceNumber
            // 
            txtInvoiceNumber.Location = new Point(634, 37);
            txtInvoiceNumber.Name = "txtInvoiceNumber";
            txtInvoiceNumber.ReadOnly = true;
            txtInvoiceNumber.Size = new Size(100, 23);
            txtInvoiceNumber.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(481, 77);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 2;
            label2.Text = "Invoice date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(67, 57);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 4;
            label3.Text = "Bill to";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 88);
            label4.Name = "label4";
            label4.Size = new Size(100, 15);
            label4.TabIndex = 6;
            label4.Text = "Customer Name :";
            // 
            // cmbCustomer
            // 
            cmbCustomer.FormattingEnabled = true;
            cmbCustomer.Location = new Point(153, 85);
            cmbCustomer.Name = "cmbCustomer";
            cmbCustomer.Size = new Size(121, 23);
            cmbCustomer.TabIndex = 7;
            // 
            // btnInvoiceSave
            // 
            btnInvoiceSave.BackColor = Color.White;
            btnInvoiceSave.FlatStyle = FlatStyle.Flat;
            btnInvoiceSave.ForeColor = Color.Green;
            btnInvoiceSave.Location = new Point(672, 224);
            btnInvoiceSave.Name = "btnInvoiceSave";
            btnInvoiceSave.Size = new Size(75, 23);
            btnInvoiceSave.TabIndex = 9;
            btnInvoiceSave.Text = "Save";
            btnInvoiceSave.UseVisualStyleBackColor = false;
            btnInvoiceSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.Red;
            btnCancel.Location = new Point(672, 283);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 182);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 12;
            label5.Text = "Item :";
            // 
            // cmbItem
            // 
            cmbItem.FormattingEnabled = true;
            cmbItem.Location = new Point(58, 200);
            cmbItem.Name = "cmbItem";
            cmbItem.Size = new Size(79, 23);
            cmbItem.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 255);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 15;
            label7.Text = "Quentity :";
            // 
            // dgvItems
            // 
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Columns.AddRange(new DataGridViewColumn[] { ItemName, price, Quantity, Total, Delete });
            dgvItems.Location = new Point(199, 182);
            dgvItems.Name = "dgvItems";
            dgvItems.Size = new Size(423, 198);
            dgvItems.TabIndex = 18;
            // 
            // ItemName
            // 
            ItemName.HeaderText = "Item";
            ItemName.Name = "ItemName";
            // 
            // price
            // 
            price.HeaderText = "Price";
            price.Name = "price";
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Qty";
            Quantity.Name = "Quantity";
            // 
            // Total
            // 
            Total.HeaderText = "Total";
            Total.Name = "Total";
            // 
            // Delete
            // 
            Delete.HeaderText = "Delete";
            Delete.Name = "Delete";
            Delete.ReadOnly = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(324, 403);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 19;
            label8.Text = "Total :";
            // 
            // txtInvoiceTotal
            // 
            txtInvoiceTotal.Location = new Point(368, 400);
            txtInvoiceTotal.Name = "txtInvoiceTotal";
            txtInvoiceTotal.Size = new Size(100, 23);
            txtInvoiceTotal.TabIndex = 20;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(58, 285);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(120, 23);
            numQuantity.TabIndex = 21;
            // 
            // dtpInvoiceDate
            // 
            dtpInvoiceDate.Location = new Point(567, 71);
            dtpInvoiceDate.Name = "dtpInvoiceDate";
            dtpInvoiceDate.Size = new Size(200, 23);
            dtpInvoiceDate.TabIndex = 22;
            // 
            // btnAddItem
            // 
            btnAddItem.BackColor = Color.White;
            btnAddItem.ForeColor = Color.DarkBlue;
            btnAddItem.Location = new Point(62, 338);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(75, 23);
            btnAddItem.TabIndex = 23;
            btnAddItem.Text = "Add Item";
            btnAddItem.UseVisualStyleBackColor = false;
            btnAddItem.Click += btnAddItem_Click;
            // 
            // FrmInvoice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 478);
            Controls.Add(btnAddItem);
            Controls.Add(dtpInvoiceDate);
            Controls.Add(numQuantity);
            Controls.Add(txtInvoiceTotal);
            Controls.Add(label8);
            Controls.Add(dgvItems);
            Controls.Add(label7);
            Controls.Add(cmbItem);
            Controls.Add(label5);
            Controls.Add(btnCancel);
            Controls.Add(btnInvoiceSave);
            Controls.Add(cmbCustomer);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtInvoiceNumber);
            Controls.Add(label1);
            Name = "FrmInvoice";
            Text = "Invoice Details ";
            Load += FrmInvoice_Load;
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtInvoiceNumber;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cmbCustomer;
        private Button btnInvoiceSave;
        private Button btnCancel;
        private Label label5;
        private ComboBox cmbItem;
        private Label label7;
        private DataGridView dgvItems;
        private Label label8;
        private TextBox txtInvoiceTotal;
        private NumericUpDown numQuantity;
        private DateTimePicker dtpInvoiceDate;
        private Button btnAddItem;
        private DataGridViewTextBoxColumn ItemName;
        private DataGridViewTextBoxColumn price;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewButtonColumn Delete;
    }
}
