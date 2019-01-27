namespace MaximumTechnology
{
    partial class frmStaffMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStaffMenu));
            this.panelTop = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.picSettings = new System.Windows.Forms.PictureBox();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTransactionsLog = new System.Windows.Forms.Label();
            this.picPurchase = new System.Windows.Forms.PictureBox();
            this.picTransactions = new System.Windows.Forms.PictureBox();
            this.picInventory = new System.Windows.Forms.PictureBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPurchase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.IndianRed;
            this.panelTop.Controls.Add(this.label6);
            this.panelTop.Controls.Add(this.picSettings);
            this.panelTop.Controls.Add(this.picLogout);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(938, 106);
            this.panelTop.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.IndianRed;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(12, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(208, 42);
            this.label6.TabIndex = 2;
            this.label6.Text = "Staff Menu";
            // 
            // picSettings
            // 
            this.picSettings.BackgroundImage = global::MaximumTechnology.Properties.Resources.SettingsIconV4;
            this.picSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSettings.Location = new System.Drawing.Point(723, 12);
            this.picSettings.Name = "picSettings";
            this.picSettings.Size = new System.Drawing.Size(101, 83);
            this.picSettings.TabIndex = 1;
            this.picSettings.TabStop = false;
            this.picSettings.Click += new System.EventHandler(this.picSettings_Click);
            // 
            // picLogout
            // 
            this.picLogout.BackgroundImage = global::MaximumTechnology.Properties.Resources.LogoutIconV4;
            this.picLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLogout.Location = new System.Drawing.Point(830, 18);
            this.picLogout.Name = "picLogout";
            this.picLogout.Size = new System.Drawing.Size(87, 72);
            this.picLogout.TabIndex = 0;
            this.picLogout.TabStop = false;
            this.picLogout.Click += new System.EventHandler(this.picLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 42);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inventory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(716, 345);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 42);
            this.label3.TabIndex = 8;
            this.label3.Text = "Purchase";
            // 
            // lblTransactionsLog
            // 
            this.lblTransactionsLog.AutoSize = true;
            this.lblTransactionsLog.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransactionsLog.Location = new System.Drawing.Point(357, 345);
            this.lblTransactionsLog.Name = "lblTransactionsLog";
            this.lblTransactionsLog.Size = new System.Drawing.Size(227, 42);
            this.lblTransactionsLog.TabIndex = 6;
            this.lblTransactionsLog.Text = "Invoice Log";
            // 
            // picPurchase
            // 
            this.picPurchase.BackgroundImage = global::MaximumTechnology.Properties.Resources.Purchase;
            this.picPurchase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picPurchase.Location = new System.Drawing.Point(689, 124);
            this.picPurchase.Name = "picPurchase";
            this.picPurchase.Size = new System.Drawing.Size(237, 218);
            this.picPurchase.TabIndex = 7;
            this.picPurchase.TabStop = false;
            this.picPurchase.Click += new System.EventHandler(this.picPurchase_Click);
            // 
            // picTransactions
            // 
            this.picTransactions.BackgroundImage = global::MaximumTechnology.Properties.Resources.TransactionLog;
            this.picTransactions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picTransactions.Location = new System.Drawing.Point(355, 124);
            this.picTransactions.Name = "picTransactions";
            this.picTransactions.Size = new System.Drawing.Size(237, 218);
            this.picTransactions.TabIndex = 5;
            this.picTransactions.TabStop = false;
            this.picTransactions.Click += new System.EventHandler(this.picTransactions_Click);
            // 
            // picInventory
            // 
            this.picInventory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picInventory.Image = global::MaximumTechnology.Properties.Resources.Inventory;
            this.picInventory.Location = new System.Drawing.Point(12, 124);
            this.picInventory.Name = "picInventory";
            this.picInventory.Size = new System.Drawing.Size(237, 218);
            this.picInventory.TabIndex = 1;
            this.picInventory.TabStop = false;
            this.picInventory.Click += new System.EventHandler(this.picInventory_Click);
            // 
            // frmStaffMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(938, 403);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.picPurchase);
            this.Controls.Add(this.lblTransactionsLog);
            this.Controls.Add(this.picTransactions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picInventory);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStaffMenu";
            this.Text = "Staff Menu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStaffMenu_FormClosed);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPurchase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox picInventory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picPurchase;
        private System.Windows.Forms.Label lblTransactionsLog;
        private System.Windows.Forms.PictureBox picTransactions;
        private System.Windows.Forms.PictureBox picLogout;
        private System.Windows.Forms.PictureBox picSettings;
        private System.Windows.Forms.Label label6;
    }
}