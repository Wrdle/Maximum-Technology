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
    public partial class frmNewStaff : Form
    {
        public int id = -1;
        public frmNewStaff()
        {
            InitializeComponent();
        }

        private void frmNewStaff_Load(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            connetionString = @"Server=localhost\sqlexpress; Initial Catalog = Maximum Technology; User ID = MaximumTech; Password = password";



            sql = "SELECT AllUsers.Firstname, AllUsers.Lastname, AllUsers.UserID, AllUsers.Username FROM AllUsers WHERE UserID != ALL (SELECT ID FROM AllStaff);";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    this.dgvCustomers.Rows.Add(dataReader.GetValue(0).ToString() + " " + dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString());
                }
                dataReader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection to server. Error: " + ex);
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
        }

        private void btnCreateStaff_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                if (numAccessLevel.Text != "" && txtPosition.Text != "" && comStatus.Text != "")
                {
                    try
                    {
                        string sql = "INSERT INTO AllStaff (DOB, Position, Status, AccessLevel, ID) VALUES ('" + calDOB.Value.Date.ToString("yyyy/MM/dd") + "', '" + txtPosition.Text + "', '" + comStatus.Text + "', " + numAccessLevel.Text + ", " + id + ");";

                        string connectionString = null;
                        SqlConnection connection;
                        SqlCommand command;
                        connectionString = @"Server=localhost\sqlexpress; Initial Catalog = Maximum Technology; User ID = MaximumTech; Password = password";
                        connection = new SqlConnection(connectionString);

                        connection.Open();
                        command = new SqlCommand(sql, connection);
                        command.ExecuteReader();
                        connection.Close();
                        MessageBox.Show("New staff member successfully created");
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("We ran into a problem... Error: " + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Please ensure all fields are filled ina");
                }
            }
            else
            {
                MessageBox.Show("Please select a user");
            }
        }
    }
}
