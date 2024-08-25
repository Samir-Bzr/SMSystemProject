using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Gui.OtherGui;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMSystem.Data.EF;
using SMSystem.Core.Models;

namespace SMSystem.Gui.UserGui
{
    public partial class UserAddForm : Form
    {
        // Fileds
        private readonly int id;
        private readonly UserUserControl userUserControl;
        private readonly LoadingUser loading;
        private Data.EF.IDataHelper<Users> _dataHelper;
        private Users users;
        private int ResultAddOrEdit;

        public bool IsUsersEmpty { get; }

        // Constructores
        public UserAddForm(int Id, UserUserControl userUserControl,bool IsUsersEmpty)
        {
            InitializeComponent();
            // Set Property Instance
            id = Id;
            this.userUserControl = userUserControl;
            this.IsUsersEmpty = IsUsersEmpty;
            loading = LoadingUser.Instance();
            _dataHelper = (Data.EF.IDataHelper<Users>)ContainerConfig.ObjectType("Users");
            // Set DataFileds for Edit void
            if (id > 0)
            {
                SetDataToFileds();
            }
        }

        // Events
        private void buttonSave_Click(object sender, EventArgs e)
        {
            // check requirments of fileds
            if (IsRequiredFiledEmpty())
            {
                MessageCollection.ShowEmptyFields();
            }
            else
            {
                loading.Show();
                // Check if add or edit
                if (id == 0)
                {
                    // Add
                    AddData();
                }
                else
                {
                    // Edit
                    EditData();
                }
                loading.Hide();
            }
        }
        #region Methods
        private async void AddData()
        {
            // Set Data
            SetDataForAdd();
            // Send data and get result
            ResultAddOrEdit = await Task.Run(() => _dataHelper.Add(users));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfuly
            {
                // Show Notifiction
                MessageCollection.ShowAddNotification();
                ClearFileds();
                // Updat View
                userUserControl.LoadData();
                Close();
            }
            else // End with database error
            {
                MessageCollection.ShowServerMessage();
            }
        }
        private async void EditData()
        {
            // Set Data
            SetDataForEdit();
            ResultAddOrEdit = await Task.Run(() => _dataHelper.Edit(users));
            // check the result of proccess
            if (ResultAddOrEdit == 1) // Seccessfuly
            {
                // Show Notification
                MessageCollection.ShowEditNotification();
                // Updat View
                userUserControl.LoadData();
                Close();
            }
            else // End with database error
            {
                MessageCollection.ShowServerMessage();
            }
        }

        private void ClearFileds()
        {
        }

        private async void SetDataToFileds()
        {
            if (_dataHelper.IsDbConnect())
            {
                users = await Task.Run(() => _dataHelper.Find(id));
                textBoxName.Text = users.Nomcomplet;
                textBoxPassword.Text = users.Pwd;
                textBoxUserName.Text = users.Login;
                textBoxPassword.Text = users.Pwd;
                comboBoxRole.SelectedItem = users.IdRole;
            }
            else
            {
                MessageCollection.ShowServerMessage();

            }
            users = null;
        }
        private void SetDataForAdd()
        {
            users = new Users
            {
                Nomcomplet = textBoxName.Text,
                Login = textBoxUserName.Text,
                Pwd=textBoxPassword.Text,
                IdRole=Convert.ToInt32( comboBoxRole.SelectedItem.ToString()),
            };
        }
        private void SetDataForEdit()
        {
            users = new Users
            {
                IdUser = this.id,
                Nomcomplet = textBoxName.Text,
                Login = textBoxUserName.Text,
                Pwd = textBoxPassword.Text,
                IdRole = Convert.ToInt32(comboBoxRole.SelectedItem.ToString()),
            };
        }
        private bool IsRequiredFiledEmpty()
        {
            if (textBoxName.Text == string.Empty 
                || textBoxPassword.Text == string.Empty
                || textBoxUserName.Text == string.Empty
                || comboBoxRole.SelectedItem == null
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        private void UserAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsUsersEmpty)
            {
                Application.Exit();
                MessageBox.Show("اعد تشغيل البرنامج لطفا");
            }
        }
    }
}
