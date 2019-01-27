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
    public partial class frmManagerSettings : Form
    {
        public long id = 0;
        public frmManagerSettings()
        {
            InitializeComponent();
        }

        private void frmManagerSettings_Load(object sender, EventArgs e)
        {
            refreshDGV();
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvStaff.Rows[e.RowIndex];
                string staffid = row.Cells[1].Value.ToString();

                string connetionString = null;
                SqlConnection connection;
                SqlCommand command;
                string sql = null;
                SqlDataReader dataReader;
                connetionString = @"Server=localhost\sqlexpress; Initial Catalog = Maximum Technology; User ID = MaximumTech; Password = password";

                sql = "SELECT * FROM AllUsers JOIN AllStaff ON AllStaff.ID = AllUsers.UserID WHERE AllStaff.StaffID='" + staffid + "';";
                connection = new SqlConnection(connetionString);
                try
                {
                    connection.Open();
                    command = new SqlCommand(sql, connection);
                    dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        lblStaffID.Text = dataReader.GetByte(dataReader.GetOrdinal("StaffID")).ToString();
                        txtFirstname.Text = dataReader.GetString(dataReader.GetOrdinal("Firstname"));
                        try
                        {
                            txtMiddlename.Text = dataReader.GetString(dataReader.GetOrdinal("Middlename"));
                        }
                        catch { }

                        txtLastname.Text = dataReader.GetString(dataReader.GetOrdinal("Lastname"));

                        try
                        {
                            txtAddress.Text = dataReader.GetString(dataReader.GetOrdinal("HomeAddress"));
                        }
                        catch { }

                        try
                        {
                            txtPhone.Text = dataReader.GetString(dataReader.GetOrdinal("Phone"));
                        }
                        catch { }
                        txtEmail.Text = dataReader.GetString(dataReader.GetOrdinal("Email"));
                        txtUsername.Text = dataReader.GetString(dataReader.GetOrdinal("Username"));
                        txtPassword.Text = dataReader.GetString(dataReader.GetOrdinal("Password"));
                        numAccessLevel.Value = dataReader.GetByte(dataReader.GetOrdinal("AccessLevel"));
                        comStatus.SelectedItem = dataReader.GetString(dataReader.GetOrdinal("Status"));
                        txtPosition.Text = dataReader.GetString(dataReader.GetOrdinal("Position"));
                        id = dataReader.GetInt64(dataReader.GetOrdinal("UserID"));
                        DateTime DOB = dataReader.GetDateTime(dataReader.GetOrdinal("DOB"));
                        calDOB.Value = DOB;
                    }
                    dataReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not open connection to server. Error: " + ex);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                long value;
                if (long.TryParse(txtPhone.Text, out value) || txtPhone.Text == "")
                {
                    if (txtUsername.Text.Contains(' ') == false || txtPassword.Text.Contains(' ') == false || txtEmail.Text.Contains(' ') == false)
                    {
                        if (txtFirstname.Text == "" || txtLastname.Text == "" || txtUsername.Text == "" || txtPassword.Text == "" || txtPosition.Text == "" || comStatus.Text == "" || numAccessLevel.Text == "")
                        {
                            MessageBox.Show("There are missing feilds. Please try again.");
                        }
                        else
                        {
                            try
                            {
                                string sql = "UPDATE AllUsers SET"
                                + " Firstname ='" + txtFirstname.Text + "', " + " Middlename =";
                                if (txtMiddlename.Text == "")
                                    sql += "null";
                                else
                                    sql += " '" + txtMiddlename.Text + "'";

                                sql += ", Lastname ='" + txtLastname.Text + "', HomeAddress =";

                                if (txtAddress.Text == "")
                                    sql += "null, ";
                                else
                                    sql += " '" + txtAddress.Text + "', ";

                                sql += "Phone = ";

                                if (txtPhone.Text == "")
                                    sql += "null";
                                else
                                    sql += " '" + txtPhone.Text + "'";

                                sql += ", Email ='" + txtEmail.Text + "', "
                                + " Username ='" + txtUsername.Text + "', "
                                + " Password ='" + txtPassword.Text + "' WHERE UserID = '" + id + "';";

                                string connectionString = null;
                                SqlConnection connection;
                                SqlCommand command;
                                connectionString = @"Server=localhost\sqlexpress; Initial Catalog = Maximum Technology; User ID = MaximumTech; Password = password";
                                connection = new SqlConnection(connectionString);

                                connection.Open();
                                command = new SqlCommand(sql, connection);
                                command.ExecuteReader();
                                connection.Close();

                                DateTime selectedDate = Convert.ToDateTime(calDOB.Value.Date);
                                if (selectedDate >= DateTime.Now.AddDays(-7))
                                {
                                    MessageBox.Show("Date selected was invalid.");
                                }
                                else
                                {
                                    sql = "UPDATE AllStaff SET"
                                    + " Position ='" + txtPosition.Text + "', "
                                    + " Status ='" + comStatus.Text + "', "
                                    + " AccessLevel ='" + Convert.ToByte(numAccessLevel.Value) + "', "
                                    + " DOB ='" + selectedDate.ToString("yyyy-MM-dd") + "' WHERE StaffID = '" + Convert.ToInt32(lblStaffID.Text) + "';";
                                    SqlConnection connectionStaff = new SqlConnection(connectionString);
                                    connection.Open();
                                    SqlCommand commandStaff = new SqlCommand(sql, connection);
                                    commandStaff.ExecuteReader();
                                    MessageBox.Show("User information was updated successfully");
                                    refreshDGV();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("There was a problem updating user information. Error: " + ex);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Make sure your Username, Password and Email does not contain any spaces");
                    }
                }
                else
                {
                    MessageBox.Show("Make sure your phone number only contains numbers");
                }
            }
            else
            {
                MessageBox.Show("Please select a user");
            }
        }

        private void refreshDGV()
        {
            dgvStaff.Rows.Clear();
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            connetionString = @"Server=localhost\sqlexpress; Initial Catalog = Maximum Technology; User ID = MaximumTech; Password = password";



            sql = "SELECT AllUsers.Firstname, AllUsers.Lastname, AllStaff.StaffID, AllStaff.Position FROM AllUsers JOIN AllStaff ON AllStaff.ID = AllUsers.UserID;";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    this.dgvStaff.Rows.Add(dataReader.GetValue(0).ToString() + " " + dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString());
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection to server. Error: " + ex);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmNewStaff frm = new frmNewStaff();
            frm.Show();
        }

        private void frmManagerSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmStaffMenu frm = new frmStaffMenu();
            frm.Show();
        }

        private void picLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemoveMember_Click(object sender, EventArgs e)
        {
            if (lblStaffID.Text != "")
            {
                try
                {
                    if (numAccessLevel.Value != 1)
                    {
                        string connectionString = @"Server=localhost\sqlexpress; Initial Catalog = Maximum Technology; User ID = MaximumTech; Password = password";
                        SqlConnection connection = new SqlConnection(connectionString);
                        connection.Open();
                        string sql = "DELETE FROM AllStaff WHERE StaffID= " + lblStaffID.Text + ";";
                        SqlCommand command = new SqlCommand(sql, connection);
                        command.ExecuteReader();
                        connection.Close();
                        refreshDGV();
                    }
                    else
                    {
                        MessageBox.Show("You cannot delete the manager");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please select a user");
            }
        }
    }
}
