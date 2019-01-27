namespace MaximumTechnology
{
    partial class frmInvoiceLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoiceLog));
            this.panelTop = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.clmnAccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnTransactionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.IndianRed;
            this.panelTop.Controls.Add(this.label6);
            this.panelTop.Controls.Add(this.picLogout);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1283, 106);
            this.panelTop.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.IndianRed;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(12, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(302, 42);
            this.label6.TabIndex = 3;
            this.label6.Text = "Transaction Log";
            // 
            // picLogout
            // 
            this.picLogout.BackgroundImage = global::MaximumTechnology.Properties.Resources.LogoutIconV4;
            this.picLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLogout.Location = new System.Drawing.Point(1191, 22);
            this.picLogout.Name = "picLogout";
            this.picLogout.Size = new System.Drawing.Size(80, 62);
            this.picLogout.TabIndex = 2;
            this.picLogout.TabStop = false;
            this.picLogout.Click += new System.EventHandler(this.picLogout_Click);
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnAccountID,
            this.clmnPrice,
            this.clmnGST,
            this.clmnDateTime,
            this.clmnTransactionID});
            this.dgvTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransactions.Location = new System.Drawing.Point(0, 106);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.RowTemplate.Height = 31;
            this.dgvTransactions.Size = new System.Drawing.Size(1283, 496);
            this.dgvTransactions.TabIndex = 2;
            // 
            // clmnAccountID
            // 
            this.clmnAccountID.HeaderText = "Account ID";
            this.clmnAccountID.Name = "clmnAccountID";
            // 
            // clmnPrice
            // 
            this.clmnPrice.HeaderText = "Price";
            this.clmnPrice.Name = "clmnPrice";
            // 
            // clmnGST
            // 
            this.clmnGST.HeaderText = "GST";
            this.clmnGST.Name = "clmnGST";
            // 
            // clmnDateTime
            // 
            this.clmnDateTime.HeaderText = "Date/Time";
            this.clmnDateTime.Name = "clmnDateTime";
            // 
            // clmnTransactionID
            // 
            this.clmnTransactionID.HeaderText = "Invoice ID";
            this.clmnTransactionID.Name = "clmnTransactionID";
            this.clmnTransactionID.ReadOnly = true;
            // 
            // frmInvoiceLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 602);
            this.Controls.Add(this.dgvTransactions);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInvoiceLog";
            this.Text = "Transaction Log";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTransactionLog_FormClosed);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.PictureBox picLogout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnAccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnTransactionID;
    }
}