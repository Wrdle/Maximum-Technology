using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaximumTechnology
{
    public partial class frmInvoiceLog : Form
    {
        public frmInvoiceLog()
        {
            InitializeComponent();

            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            connetionString = @"Server=localhost\sqlexpress; Initial Catalog = Maximum Technology; User ID = MaximumTech; Password = password";
            sql = "SELECT InvoiceID, UserID, SUM(PurchasePrice) AS 'Price', SUM(GST) AS 'GST', [DateTime] FROM [Maximum Technology].[dbo].[Invoices] GROUP BY InvoiceID, UserID, DateTime;";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    dgvTransactions.Rows.Add(dataReader.GetValue(0), dataReader.GetValue(1), dataReader.GetValue(2), dataReader.GetValue(3), dataReader.GetValue(4));
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! \n\n Error: " + ex.ToString());
            }
        }
        
        private void picLogout_Click(object sender, EventArgs e)
        {
            frmStaffMenu frm = new frmStaffMenu();
            frm.Show();
            this.Hide();
        }

        private void frmTransactionLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmStaffMenu frm = new frmStaffMenu();
            frm.Show();
        }
    }
}
