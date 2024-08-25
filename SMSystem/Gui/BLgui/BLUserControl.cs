using SMSystem.Code;
using SMSystem;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Data.EF;
using SMSystem.Gui.OtherGui;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMSystem.Core.Models;

namespace SMSystem.Gui.BLgui
{
    public partial class BLUserControl : UserControl
    { private readonly Data.EF.IDataHelper<BonLivraison> _dataHelper;
        private readonly LoadingUser loading;
        private int RowId;
        private static BLUserControl _blUser;
        private List<int> IdList = new List<int>();
        private Label labelEmptyData;
        private string searchItem;
        public BLUserControl()



        // Constructores

        {
            InitializeComponent();
            labelEmptyData = ComponentsObject.Instance().LabelEmptyData();
            _dataHelper = (Data.EF.IDataHelper<BonLivraison>)ContainerConfig.ObjectType("BON_LIVRAISON");
            loading = LoadingUser.Instance();
            LoadData();
        }

        #region Events


        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }





        private void buttonPrint_Click(object sender, EventArgs e)
        {


        }





        #endregion

        // Methods
        #region Methods
        public async void LoadData()
        {
            loading.Show();
            // Check if connection is available
            if (_dataHelper.IsDbConnect())
            {
                // Loading Data
                dataGridView1.DataSource = await Task.Run(() => _dataHelper.GetData());

                SetDataGridViewColumns();
            }
            else
            {
                MessageCollection.ShowServerMessage();
            }
            loading.Hide();

            // Show Empty Label Data
            ShowLabelIfEmptyData();
        }

        public async void LoadDataForSearch()
        {
            if (textBoxSearch.Text == string.Empty)
            {
                LoadData();
            }
            else
            {
                loading.Show();
                searchItem = textBoxSearch.Text;
                // Check if connection is available
                if (_dataHelper.IsDbConnect())
                {
                    // Loading Data
                    dataGridView1.DataSource = await Task.Run(() => _dataHelper.Search(searchItem));
                    SetDataGridViewColumns();
                }
                else
                {
                    MessageCollection.ShowServerMessage();
                }
                loading.Hide();
            }
            // Show Empty Label Data
            ShowLabelIfEmptyData();

        }

        // Get a List of Id for selcted rows
        private void SetIDSelcted()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected) IdList.Add(Convert.ToInt32(row.Cells[0].Value));
            }
        }
        private void SetDataGridViewColumns()
        {
            

            // Hide Columns
        }

        // Singleton Instance
        public static UserControl Instance()
        {
            return _blUser ?? (new BLUserControl());
        }
        //Add and Show Empty Label 
        private void ShowLabelIfEmptyData()
        {
            dataGridView1.Controls.Add(labelEmptyData);
            if (dataGridView1.Rows.Count > 0)
            {
                labelEmptyData.Visible = false;
            }
            else
            {
                labelEmptyData.Visible = true;
            }
        }
        #endregion

        private void buttonRefresh_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSearch_Click_1(object sender, EventArgs e)
        {
            LoadDataForSearch();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadDataForSearch();
        }

        private void buttonEdit_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                RowId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdBl"].Value);
                DetailBLform detailBLform = new DetailBLform (RowId);
                detailBLform.Show();
            }
            else
            {
                MessageCollection.ShowEmptyDataMessage();
            }
        }
        
            private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                buttonEdit_Click_1(sender, e); }

            private void buttonDelete_Click(object sender, EventArgs e)
            {
                try
                {
                    if (dataGridView1.RowCount > 0)
                    {
                        SetIDSelcted();
                        var result = MessageCollection.DeleteActtion();
                        if (result == true)
                        {
                            loading.Show();
                            if (_dataHelper.IsDbConnect())
                            {
                                if (IdList.Count > 0)
                                {
                                    for (int i = 0; i < IdList.Count; i++)
                                    {
                                        RowId = IdList[i];
                                        _dataHelper.Delete(RowId);
                                    }
                                    LoadData();
                                    MessageCollection.ShowDeletNotification();
                                }
                                else
                                {
                                    MessageCollection.ShowSlectRowsNotification();

                                }

                            }
                            else
                            {
                                MessageCollection.ShowServerMessage();
                            }
                        }
                    }
                    else
                    {
                        MessageCollection.ShowEmptyDataMessage();

                    }
                }
                catch
                {
                    MessageCollection.ShowServerMessage();
                }
                loading.Hide();

            }
       

    }
}