using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MaximumTechnology
{
    public partial class frmInventory : Form
    {
        int id;
        public frmInventory()
        {
            InitializeComponent();

            if (User.AccessLevel > 2)
                btnDelete.Hide();
            else
                btnDelete.Show();

        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            refreshData();
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    id = Convert.ToInt16(dgvInventory.Rows[e.RowIndex].Cells[2].Value);
                    lblID.Text = "Inventory ID: " + dgvInventory.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtName.Text = dgvInventory.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtModel.Text = dgvInventory.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtPrice.Text = dgvInventory.Rows[e.RowIndex].Cells[3].Value.ToString();
                    numQuantity.Value = Convert.ToInt32(dgvInventory.Rows[e.RowIndex].Cells[4].Value.ToString());
                    txtDescription.Text = dgvInventory.Rows[e.RowIndex].Cells[5].Value.ToString();
                    txtGST.Text = dgvInventory.Rows[e.RowIndex].Cells[6].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error grabbing item information. \n\n Error: " + ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (User.AccessLevel <= 2)
            {
                if (txtNewName.Text == "" || txtNewModel.Text == "" || txtNewPrice.Text == "" || numNewQuantity.Value == 0 || txtDescription.Text == "" || txtGST.Text == "")
                {
                    if (id == 0)
                    {
                        MessageBox.Show("You have not selected an item");
                    }
                    else
                    {
                        string sName = txtName.Text;
                        string sModel = txtModel.Text;
                        string sDescription = txtDescription.Text;
                        int iQuantity = Convert.ToInt32(numQuantity.Value.ToString());
                        decimal dPrice;
                        decimal dGST;
                        try
                        {
                            dPrice = Convert.ToDecimal(txtPrice.Text);
                            try
                            {
                                dGST = Convert.ToDecimal(txtGST.Text);

                                string sql = "UPDATE Inventory SET Price =" + dPrice + ", Model# = '" + sModel + "', QTY = " + iQuantity + ", Description = '" + sDescription + "', GST =" + dGST + ", Name ='" + sName + "' WHERE InventoryID =" + id + ";";
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
                                    command.Dispose();
                                    dataReader.Close();
                                    connection.Close();
                                    refreshData();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("There was an error updating inventory. \n\n + Error: " + ex);
                                }

                            }
                            catch
                            {
                                MessageBox.Show("GST entered is not valid.");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Price entered is not valid.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("All feilds must be filled in.");
                }
            }
            else
            {
                MessageBox.Show("You do not have sufficient permissions to perform this task.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("You have not selected an item.");
            }
            else
            {
                string sql = "DELETE FROM Inventory WHERE InventoryID=" + id + ";";
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
                    command.Dispose();
                    dataReader.Close();
                    connection.Close();
                    refreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error updating inventory. \n\n + Error: " + ex);
                }
            }
        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            if (txtNewName.Text == "" || txtNewModel.Text == "" || txtNewPrice.Text == "" || numNewQuantity.Value == 0 || txtNewDescription.Text == "" || txtNewGST.Text == "")
            {
                MessageBox.Show("All fields must filled in.");
            }
            else
            {
                decimal dPrice;
                decimal dGST;
                try
                {
                    dPrice = Convert.ToDecimal(txtNewPrice.Text);
                    try
                    {
                        dGST = Convert.ToDecimal(txtNewGST.Text);
                        string sql = "INSERT INTO Inventory VALUES(" + dPrice + ", '" + txtNewModel.Text + "', " + numNewQuantity.Value + ", '" + txtDescription.Text + "', " + dGST + ", '" + txtNewName.Text + "');";
                        SqlConnection connection;
                        SqlCommand command;
                        SqlDataReader datareader;
                        string connectionString = @"Server=localhost\sqlexpress; Initial Catalog = Maximum Technology; User ID = MaximumTech; Password = password";
                        connection = new SqlConnection(connectionString);
                        try
                        {
                            connection.Open();
                            command = new SqlCommand(sql, connection);
                            datareader = command.ExecuteReader();
                            command.Dispose();
                            connection.Dispose();
                            datareader.Close();
                            refreshData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("There was en error accessing the database. \n\n Error: " + ex.ToString());
                        }
                    }
                    catch
                    {
                        MessageBox.Show("The GST amount you entered in invalid");
                    }
                }
                catch
                {
                    MessageBox.Show("The price you entered is not valid");
                }
            }
        }

        public void refreshData()
        {
            dgvInventory.Rows.Clear();
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            connetionString = @"Server=localhost\sqlexpress; Initial Catalog = Maximum Technology; User ID = MaximumTech; Password = password";
            sql = "SELECT * FROM Inventory";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    dgvInventory.Rows.Add(dataReader.GetValue(6), dataReader.GetValue(2), dataReader.GetValue(0), dataReader.GetValue(1), dataReader.GetValue(3), dataReader.GetValue(4), dataReader.GetValue(5));
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmStaffMenu frm = new frmStaffMenu();
            frm.Show();
            this.Close();
        }

        private void frmInventory_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmStaffMenu frm = new frmStaffMenu();
            frm.Show();
        }
    }
}
