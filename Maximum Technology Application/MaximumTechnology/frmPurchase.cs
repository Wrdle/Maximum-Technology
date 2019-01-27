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
    public partial class frmPurchase : Form
    {
        public int itemsAmount = 0;
        public frmPurchase()
        {
            InitializeComponent();
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            connetionString = @"Server=localhost\sqlexpress; Initial Catalog = Maximum Technology; User ID = MaximumTech; Password = password";
            sql = "SELECT InventoryID, Name, Description, Price, Model#, QTY FROM Inventory";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    dgvInventory.Rows.Add(dataReader.GetValue(0), dataReader.GetValue(1), dataReader.GetValue(2), dataReader.GetValue(3), dataReader.GetValue(4), dataReader.GetValue(5));
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }

        private void frmPurchase_FormClosed(object sender, FormClosedEventArgs e)
        {
            exit();
        }

        private void picLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            exit();
        }

        public void exit()
        {
            GlobalVariables.cart.Clear();
            GlobalVariables.cartPrice = 0;
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

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dgvInventory.Rows[e.RowIndex].Cells[5].Value) > 0)
                {
                    if (e.RowIndex >= 0)
                    {

                        string sql = "SELECT InventoryID, GST FROM Inventory WHERE InventoryID='" + dgvInventory.Rows[e.RowIndex].Cells[0].Value.ToString() + "';";

                        SqlConnection connection;
                        SqlCommand command;
                        SqlDataReader dataReader;
                        string connetionString = @"Server=localhost\sqlexpress; Initial Catalog = Maximum Technology; User ID = MaximumTech; Password = password";
                        connection = new SqlConnection(connetionString);

                        try
                        {
                            connection.Open();
                            command = new SqlCommand(sql, connection);
                            dataReader = command.ExecuteReader();
                            while (dataReader.Read())
                            {
                                stCart item = new stCart();
                                item.ModelNo = dgvInventory.Rows[e.RowIndex].Cells[4].Value.ToString();
                                item.Name = dgvInventory.Rows[e.RowIndex].Cells[1].Value.ToString();
                                item.Price = Convert.ToDecimal(dgvInventory.Rows[e.RowIndex].Cells[3].Value);
                                item.invID = Convert.ToInt32(dataReader.GetValue(0).ToString());
                                item.dGST = Convert.ToDecimal(dataReader.GetValue(1).ToString()) * Convert.ToDecimal(dgvInventory.Rows[e.RowIndex].Cells[3].Value);
                                GlobalVariables.cart.Add(item);
                                refreshCart();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error getting your data. \n\n Error: " + ex);
            }
        }


        public void refreshCart()
        {
            GlobalVariables.cartPrice = 0;
            dgvCart.Rows.Clear();

            itemsAmount = 0;


            foreach (stCart i in GlobalVariables.cart)
            {
                dgvCart.Rows.Add(i.Name, i.ModelNo, i.Price, "Remove");
                GlobalVariables.cartPrice += i.Price;
                itemsAmount += 1;
            }


            lblCost.Text = "Total Cost: $" + GlobalVariables.cartPrice;
            lblItems.Text = "Items: " + itemsAmount;
            GlobalVariables.iItems = itemsAmount;
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if(e.ColumnIndex == 3)
                {
                    GlobalVariables.cart.RemoveAt(e.RowIndex);
                    refreshCart();
                    itemsAmount -= 1;
                }
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if(GlobalVariables.cart.Count > 0)
            {
                frmCheckout frm = new frmCheckout();
                frm.Show();
                this.Hide();
                lblCost.Text = "Total Cost:";
                lblItems.Text = "Items: ";


                GlobalVariables.iItems = itemsAmount;
            }
            else
            {
                MessageBox.Show("You have not added any items to the cart");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != " ")
            {
                string sql = "SELECT InventoryID, Name, Description, Price, Model#, QTY FROM Inventory WHERE Name LIKE '%" + txtSearch.Text + "%' OR InventoryID LIKE '%" + txtSearch.Text + "%';";

                SqlConnection connection;
                SqlCommand command;
                SqlDataReader dataReader;
                string connetionString = @"Server=localhost\sqlexpress; Initial Catalog = Maximum Technology; User ID = MaximumTech; Password = password";
                connection = new SqlConnection(connetionString);

                try
                {
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        dgvSearch.Rows.Add(dataReader.GetValue(0), dataReader.GetValue(1), dataReader.GetValue(2), dataReader.GetValue(3), dataReader.GetValue(4), dataReader.GetValue(5));
                    }
                    dataReader.Close();
                    command.Dispose();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void dgvSearch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dgvInventory.Rows[e.RowIndex].Cells[5].Value) > 0)
                {
                    if (e.RowIndex >= 0)
                    {

                        string sql = "SELECT InventoryID, GST FROM Inventory WHERE InventoryID='" + dgvInventory.Rows[e.RowIndex].Cells[0].Value.ToString() + "';";

                        SqlConnection connection;
                        SqlCommand command;
                        SqlDataReader dataReader;
                        string connetionString = @"Server=localhost\sqlexpress; Initial Catalog = Maximum Technology; User ID = MaximumTech; Password = password";
                        connection = new SqlConnection(connetionString);

                        try
                        {
                            connection.Open();
                            command = new SqlCommand(sql, connection);
                            dataReader = command.ExecuteReader();
                            while (dataReader.Read())
                            {
                                stCart item = new stCart();
                                item.ModelNo = dgvInventory.Rows[e.RowIndex].Cells[4].Value.ToString();
                                item.Name = dgvInventory.Rows[e.RowIndex].Cells[1].Value.ToString();
                                item.Price = Convert.ToDecimal(dgvInventory.Rows[e.RowIndex].Cells[3].Value);
                                item.invID = Convert.ToInt32(dataReader.GetValue(0).ToString());
                                item.dGST = Convert.ToDecimal(dataReader.GetValue(1).ToString()) * Convert.ToDecimal(dgvInventory.Rows[e.RowIndex].Cells[3].Value);
                                GlobalVariables.cart.Add(item);
                                refreshCart();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error getting your data. \n\n Error: " + ex);
            }
        }
    }
}
