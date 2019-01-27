using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaximumTechnology
{
    public partial class frmStaffMenu : Form
    {
        public frmStaffMenu()
        {
            InitializeComponent();
            if (User.AccessLevel != 1)
            {
                picSettings.Hide();
            }
        }

        private void picSettings_Click(object sender, EventArgs e)
        {
            frmManagerSettings frm = new frmManagerSettings();
            frm.Show();
            this.Hide();
        }

        private void picInventory_Click(object sender, EventArgs e)
        {
            frmInventory frm = new frmInventory();
            frm.Show();
            this.Hide();
        }

        private void picTransactions_Click(object sender, EventArgs e)
        {
            frmInvoiceLog frm = new frmInvoiceLog();
            frm.Show();
            this.Hide();
        }

        private void frmStaffMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.Start(Environment.CurrentDirectory.ToString() + @"\MaximumTechnology.exe");
            Environment.Exit(0);
        }

        private void picPurchase_Click(object sender, EventArgs e)
        {
            frmPurchase frm = new frmPurchase();
            frm.Show();
            this.Hide();
        }

        private void picLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
