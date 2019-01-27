using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MaximumTechnology
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.KeyPreview = true;

            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name != "frmLogin")
                    f.Close();
            }
        }

        private void testfunction(object sender, EventArgs e)
        {
            string connectionString = null;
            SqlConnection connection;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;
            connectionString = @"Server=localhost\sqlexpress; Initial Catalog = Maximum Technology; User ID = MaximumTech; Password = password";


            string username = txtUsername.Text;
            string password = txtPassword.Text;
            sql = "SELECT AllUsers.UserID, AllUsers.Username, AllUsers.Password, AllUsers.Firstname, AllUsers.Lastname FROM AllUsers WHERE Username='" + username + "' AND Password= '" + password + "';";
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows == false)
                {
                    MessageBox.Show("Login failed. Please try again.");
                }
                else
                {
                    while (dataReader.Read())
                    {
                        if (txtUsername.Text == dataReader.GetValue(1).ToString() && txtPassword.Text == dataReader.GetValue(2).ToString())
                        {
                            User.ID = (long)Convert.ToDouble(dataReader.GetValue(0).ToString());
                            User.Username = dataReader.GetValue(1).ToString();
                            User.Firstname = dataReader.GetValue(3).ToString();
                            User.Lastname = dataReader.GetValue(4).ToString();

                            sql = "SELECT AllStaff.StaffID, AllStaff.AccessLevel FROM AllStaff WHERE ID='" + User.ID + "';";
                            SqlConnection connection2 = new SqlConnection(connectionString);
                            connection2.Open();
                            SqlCommand command2 = new SqlCommand(sql, connection2);
                            SqlDataReader dataReader2 = command2.ExecuteReader();
                            if (dataReader2.HasRows == true)
                            {
                                try
                                {
                                    while (dataReader2.Read())
                                    {
                                        User.AccessLevel = Convert.ToInt32(dataReader2.GetValue(1).ToString());
                                        User.isStaff = true;

                                        frmStaffMenu frm = new frmStaffMenu();
                                        frm.Show();
                                        this.Hide();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("There was an error trying to connect to the server. Error: " + ex);
                                }
                            }
                            else
                            {
                                User.isStaff = false;
                                frmPurchase frm = new frmPurchase();
                                frm.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Login unsuccessful. Please try again.");
                            break;
                        }
                    }
                    dataReader.Close();
                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection to server. Error: " + ex);
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                e.Handled = true;
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            frmSignup frm = new frmSignup();
            frm.Show();
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
