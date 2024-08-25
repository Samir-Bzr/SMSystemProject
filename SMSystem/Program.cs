using SMSystem.Gui;
using System;
using System.Windows.Forms;
using SMSystem.Code;
using SMSystem.Data;
using SMSystem.Data.Gestproentity;
using System.Configuration;

namespace SMSystem
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // Register dependencies before creating the main form
            // Register the connection string in your initialization code
             
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            ContainerConfig.Register("connectionString", connectionString );
            ContainerConfig.Register("Income", new IncomeEntity());
            ContainerConfig.Register("Stores", new StoreEntity());
            ContainerConfig.Register("Damage", new DamageEntity());
            ContainerConfig.Register("ConscienceCard", new ConscienceCardEntity());
            ContainerConfig.Register("Customers", new CustomersEntity());
            ContainerConfig.Register("OutComeMaterail", new OutComeMaterailMaterialsEntity());
            ContainerConfig.Register("OutOfConscinesMaterials", new OutOfConsinceMaterialEntity());
            ContainerConfig.Register("Suppliers", new SuppliersEntity());
          
            ContainerConfig.Register("OutCome", new OutComeEntity());
            ContainerConfig.Register("Materails", new MaterailsEntity());
            ContainerConfig.Register("BON_LIVRAISON", new BonLivraisonENTITY());
            ContainerConfig.Register("DETAIL_BL", new DetailBLEntity());

            Startup getStarted = new Startup();
            Application.Run(new StartForm());
        }

    }
}
