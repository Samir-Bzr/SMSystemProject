using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Core.Models;
using SMSystem.Data;
using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSystem.Gui.Analyze
{
    public partial class AnalyzeUserControl : UserControl
    {
        Data.EF.IDataHelper<Store> StoreData;
        Data.EF.IDataHelper<Materails> MaterialData;
        Data.EF.IDataHelper<Customer> CustomerData;
        Data.EF.IDataHelper<Supplier> SupplierData;
        Data.EF.IDataHelper<Income> IncomeData;
        Data.EF.IDataHelper<OutCome> OutCome;
        Data.EF.IDataHelper<Damage> Damage;
        Data.EF.IDataHelper<Users> User;

        private static AnalyzeUserControl analyzeUserControl;
        private OtherGui.LoadingUser loading;
        public AnalyzeUserControl()
        {
            InitializeComponent();
            StoreData= (Data.EF.IDataHelper<Store>)ContainerConfig.ObjectType("Stores");
            MaterialData = (Data.EF.IDataHelper<Materails>)ContainerConfig.ObjectType("Materails");
            CustomerData = (Data.EF.IDataHelper<Customer>)ContainerConfig.ObjectType("Customers");
            SupplierData = (Data.EF.IDataHelper<Supplier>)ContainerConfig.ObjectType("Suppliers");
            IncomeData = (Data.EF.IDataHelper<Income>)ContainerConfig.ObjectType("Income");
            OutCome = (Data.EF.IDataHelper<OutCome>)ContainerConfig.ObjectType("OutCome");
            Damage = (Data.EF.IDataHelper<Damage>)ContainerConfig.ObjectType("Damage");
            User = (Data.EF.IDataHelper<Users>)ContainerConfig.ObjectType("Users");
            loading = OtherGui.LoadingUser.Instance();
            SetDataToView();
        }

        private async void SetDataToView()
        {
            loading.Show();
            
            //labelStore.Text = await Task.Run(()=> StoreData.GetData().Select(x => x.Id).ToArray().Count().ToString());
            labelTotalMaterials.Text = await Task.Run(() => MaterialData.GetData().Select(x => x.Id).ToArray().Count().ToString());
            labelIncome.Text = await Task.Run(() => IncomeData.GetData().Select(x => x.Id).ToArray().Count().ToString());
            labelOutCome.Text = await Task.Run(() => OutCome.GetData().Select(x => x.Id).ToArray().Count().ToString());
            labelAvalible.Text = await Task.Run(() => MaterialData.GetData().Select(x => x.Quantity).ToArray().Sum().ToString());
            labelUsers.Text = await Task.Run(() => User.GetData().Select(x => x.IdUser).ToArray().Count().ToString());
            labelUsers.Text = await Task.Run(() => User.GetData().Select(x => x.IdUser).ToArray().Count().ToString());
            labelCustomers.Text = await Task.Run(() => CustomerData.GetData().Select(x => x.Id).ToArray().Count().ToString());
            labelSuppliers.Text = await Task.Run(() => SupplierData.GetData().Select(x => x.Id).ToArray().Count().ToString());
            loading.Hide();
        }

        internal static UserControl Instance()
        {
            return analyzeUserControl ?? (new AnalyzeUserControl());
        }
    }
}
