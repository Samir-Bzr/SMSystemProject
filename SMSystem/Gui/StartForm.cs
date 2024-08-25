using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.UserGui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SMSystem.Gui
{
    partial class StartForm : Form
    {
        
        private int StartState;

        public StartForm()
        {
            InitializeComponent();
           
        }

        private int CheckDatabaseConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Startup.ConnectionString))
                {
                    connection.Open();

                    // Check if there are any users
                    string query = "SELECT COUNT(*) FROM [USERS]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int userCount = (int)command.ExecuteScalar();
                        return userCount > 0 ? 2 : 1; // 2 for login, 1 for new user
                    }
                }
            }
            catch (SqlException)
            {
                return 3; // Error in connection
            }
        }

        private async void StartForm_Load(object sender, EventArgs e)
        {
            labelstate.Text = "جاري الاتصال بقاعدة البيانات ...";
            int startState = await Task.Run(() => CheckDatabaseConnection());

            if (startState == 1)
            {
                 //Add New User
               UserAddForm userAddForm = new UserGui.UserAddForm(0, new UserGui.UserUserControl(), true);
                userAddForm.Show();
                this.Hide();
            }
            else if (startState == 2)
            {
                // Login
               SMSystem.Gui.UserGui.UserLogin userLogin = new SMSystem.Gui.UserGui.UserLogin();
                userLogin.Show();
                this.Hide();
            }
            else
            {
                // Connection Error
                var result = MessageBox.Show("هل تود ضبط الاتصال بالسيرفر ؟", "لا يمكن الاتصال في السيرفر", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    Gui.SettingsForm settingsForm = new SettingsForm(true);
                    settingsForm.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
