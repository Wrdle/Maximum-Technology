using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaximumTechnology
{
    public partial class frmCheckout : Form
    {
        public frmCheckout()
        {
            InitializeComponent();
        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            lblItems.Text = "Items: " + GlobalVariables.iItems;
            lblPrice.Text = "Total Cost: " + GlobalVariables.cartPrice;
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (txtCardNumber.Text == null || txtCVV.Text == null || txtExpiry.Text == null || txtName.Text == null)
            {
                MessageBox.Show("Please fill all fields");
            }
            else
            {
                try
                {
                    string connectionString = @"Server=localhost\sqlexpress; Initial Catalog = Maximum Technology; User ID = MaximumTech; Password = password";
                    SqlConnection updateConnection = new SqlConnection(connectionString);
                    SqlCommand updateCommand;
                    SqlDataReader updateDataReader;
                    updateConnection.Open();

                    foreach (stCart i in GlobalVariables.cart)
                    {
                        string sqlUpdate = "UPDATE Inventory SET QTY = (SELECT QTY FROM Inventory WHERE InventoryID=" + i.invID + ")-1 WHERE InventoryID= " + i.invID + ";";

                        updateCommand = new SqlCommand(sqlUpdate, updateConnection);
                        updateDataReader = updateCommand.ExecuteReader();

                        updateCommand.Dispose();
                        updateDataReader.Close();
                    }
                    updateConnection.Close();

                    try
                    {

                        long cardNumber = Convert.ToInt64(txtCardNumber.Text);
                        int cvv = Convert.ToInt32(txtCVV.Text);
                        string expirey = txtExpiry.Text;
                        string name = txtName.Text;

                        string sql = "INSERT INTO Invoices (InvoiceID, InventoryID, UserID, Line, GST, OrderComplete, DateTime, PurchasePrice) VALUES ";
                        int x = 0;

                        foreach (var i in GlobalVariables.cart)
                        {
                            x += 1;

                            if (GlobalVariables.cart.Count == x)
                            {
                                sql += "(ISNULL((SELECT TOP 1 InvoiceID FROM Invoices ORDER BY InvoiceID DESC)+1, 1), " + i.invID + ", " + User.ID + ", " + x + ", " + i.dGST + ", " + 1 + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "', " + i.Price + ");";
                            }
                            else
                            {
                                sql += "(ISNULL((SELECT TOP 1 InvoiceID FROM Invoices ORDER BY InvoiceID DESC)+1, 1), " + i.invID + ", " + User.ID + ", " + x + ", " + i.dGST + ", " + 1 + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "', " + i.Price + "),";
                            }
                        }

                        SqlConnection connection;
                        SqlCommand command;
                        SqlDataReader dataReader;
                        connection = new SqlConnection(connectionString);
                        try
                        {
                            connection.Open();
                            command = new SqlCommand(sql, connection);
                            dataReader = command.ExecuteReader();
                            dataReader.Close();
                            command.Dispose();
                            connection.Close();
                            MessageBox.Show("Thanks for shopping with Maximum Technology!");
                            this.Hide();
                            frmStaffMenu frm = new frmStaffMenu();
                            frm.Show();
                            GlobalVariables.cart.Clear();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not open connection ! " + ex);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was an error trying to process your request. Please try again later. Error: " + ex);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please enter valid inputs. Error: " + ex.ToString());
                }
            }
        }

        private void frmCheckout_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalVariables.cart.Clear();
            if (User.isStaff == true)
            {
                frmStaffMenu frm = new frmStaffMenu();
                frm.Show();
            }
            else
            {
                Process.Start(Environment.CurrentDirectory.ToString() + @"\MaximumTechnology.exe");
                Environment.Exit(0);
            }
        }

        private void picLogout_Click(object sender, EventArgs e)
        {
            GlobalVariables.cart.Clear();
            if (User.isStaff == true)
            {
                frmStaffMenu frm = new frmStaffMenu();
                frm.Show();
                this.Close();
            }
            else
            {
                Process.Start(Environment.CurrentDirectory.ToString() + @"\MaximumTechnology.exe");
                Environment.Exit(0);
            }
        }
    }
}
