using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.OtherGui;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SMSystem.Gui.UserGui
{
    
        public partial class UserLogin : Form
        {
            public UserLogin()
            {
                InitializeComponent();
            }

            private void btnLogin_Click(object sender, EventArgs e)
            {
              
            }

            private bool AuthenticateUser(string username, string password)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(Startup.ConnectionString))
                    {
                        connection.Open();
                        string query = "SELECT COUNT(*) FROM [USERS] WHERE LOGIN = @Username AND PWD = @Password";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Username", username);
                            command.Parameters.AddWithValue("@Password", password); // Note: In a real application, you should hash passwords
                            int result = (int)command.ExecuteScalar();
                            return result > 0;
                        }
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("Database connection error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string username = textBoxUserName.Text;
            string password = textBoxPassword.Text;

            if (AuthenticateUser(username, password))
            {
                // Login successful, open main form
                this.Hide();
                Main main = new Main();
                main.Show();
                
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {

        }
    }
    }

