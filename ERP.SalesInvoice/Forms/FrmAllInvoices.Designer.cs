namespace ERP.SalesInvoice.Forms
{
    partial class FrmAllInvoices
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnNewInvoice = new Button();
            btnInvoiceEdit = new Button();
            btnInvoiceDelete = new Button();
            dgvInvoices = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).BeginInit();
            SuspendLayout();
            // 
            // btnNewInvoice
            // 
            btnNewInvoice.BackColor = Color.CornflowerBlue;
            btnNewInvoice.FlatStyle = FlatStyle.Flat;
            btnNewInvoice.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewInvoice.ForeColor = SystemColors.ButtonFace;
            btnNewInvoice.Location = new Point(684, 314);
            btnNewInvoice.Name = "btnNewInvoice";
            btnNewInvoice.Size = new Size(75, 23);
            btnNewInvoice.TabIndex = 9;
            btnNewInvoice.Text = "New";
            btnNewInvoice.UseVisualStyleBackColor = false;
            btnNewInvoice.Click += btnNewInvoice_Click;
            // 
            // btnInvoiceEdit
            // 
            btnInvoiceEdit.BackColor = SystemColors.ControlDarkDark;
            btnInvoiceEdit.FlatStyle = FlatStyle.Flat;
            btnInvoiceEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInvoiceEdit.ForeColor = SystemColors.ButtonFace;
            btnInvoiceEdit.Location = new Point(684, 354);
            btnInvoiceEdit.Name = "btnInvoiceEdit";
            btnInvoiceEdit.Size = new Size(75, 23);
            btnInvoiceEdit.TabIndex = 11;
            btnInvoiceEdit.Text = "Edit";
            btnInvoiceEdit.UseVisualStyleBackColor = false;
            btnInvoiceEdit.Click += btnEditInvoice_Click;
            // 
            // btnInvoiceDelete
            // 
            btnInvoiceDelete.BackColor = Color.Red;
            btnInvoiceDelete.FlatStyle = FlatStyle.Flat;
            btnInvoiceDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInvoiceDelete.ForeColor = SystemColors.ButtonFace;
            btnInvoiceDelete.Location = new Point(684, 399);
            btnInvoiceDelete.Name = "btnInvoiceDelete";
            btnInvoiceDelete.Size = new Size(75, 23);
            btnInvoiceDelete.TabIndex = 12;
            btnInvoiceDelete.Text = "Delete";
            btnInvoiceDelete.UseVisualStyleBackColor = false;
            btnInvoiceDelete.Click += btnDeleteInvoice_Click;
            // 
            // dgvInvoices
            // 
            dgvInvoices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInvoices.Location = new Point(71, 70);
            dgvInvoices.Name = "dgvInvoices";
            dgvInvoices.Size = new Size(545, 289);
            dgvInvoices.TabIndex = 13;
            // 
            // FrmAllInvoices
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvInvoices);
            Controls.Add(btnInvoiceDelete);
            Controls.Add(btnInvoiceEdit);
            Controls.Add(btnNewInvoice);
            Name = "FrmAllInvoices";
            Text = "FrmAllInvoices";
            Load += FrmAllInvoices_Load;
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnNewInvoice;
        private Button btnInvoiceEdit;
        private Button btnInvoiceDelete;
        private DataGridView dgvInvoices;
    }
}