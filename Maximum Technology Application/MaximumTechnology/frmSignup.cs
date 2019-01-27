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
    public partial class frmSignup : Form
    {
        public frmSignup()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtFirstname.Text == "" || txtLastname.Text == "" || txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("There are missing feilds. Please try again");
            }
            else
            { 
                string connectionString = null;
                string sql = null;
                connectionString = @"Server=localhost\sqlexpress; Initial Catalog = Maximum Technology; User ID = MaximumTech; Password = password";
                SqlConnection connectionUsername;
                SqlCommand command = new SqlCommand();
                SqlDataReader dataReaderUsername;
                connectionUsername = new SqlConnection(connectionString);

                sql = "SELECT * FROM AllUsers WHERE Username='" + txtUsername.Text + "';";

                try
                {
                    connectionUsername.Open();
                    command = new SqlCommand(sql, connectionUsername);
                    dataReaderUsername = command.ExecuteReader();
                    if (dataReaderUsername.HasRows == true)
                    {
                        MessageBox.Show("That username already exists. Please choose a different username.");
                    }
                    else
                    {
                        dataReaderUsername.Close();
                        SqlCommand command2;
                        SqlDataReader dataReader;
                        SqlConnection connection = new SqlConnection(connectionString);


                        sql = "INSERT INTO AllUsers VALUES ('" + txtUsername.Text + "', '" + txtPassword.Text + "', '" + txtFirstname.Text + "', ";
                        if (txtMiddlename.Text == "")
                            sql += "null, '";
                        else
                            sql += "'" + txtMiddlename.Text + "', '";

                        sql += txtLastname.Text + "', ";

                        if (txtPhone.Text == "")
                            sql += "null, ";
                        else
                            sql += "'" + txtPhone.Text + "', ";


                        if (txtHomeAddress.Text == "")
                            sql += "null, '";
                        else
                            sql += "'" + txtHomeAddress.Text + "', '";

                        sql += txtEmail.Text + "');";


                        try
                        {
                            connection.Open();
                            command2 = new SqlCommand(sql, connection);
                            dataReader = command2.ExecuteReader();
                            dataReader.Close();
                            MessageBox.Show("You have successfully signed up.");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Can not open connection to server. Error: " + ex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error checking if the username already exists. Please try again. \n\n Error: " + ex);
                }
            }
        }

        private void picLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSignup_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
        }
    }
}
