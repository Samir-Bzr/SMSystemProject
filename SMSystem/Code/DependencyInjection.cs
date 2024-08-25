using SMSystem.Data;
using SMSystem.Data.Gestproentity;

namespace SMSystem.Code
{
    public class DependencyInjection
    {

        // Construcotores
        public DependencyInjection()
        {
            // Inject the objets
            ContainerConfig.Register("Stores", new StoreEntity());
            ContainerConfig.Register("Materails", new MaterailsEntity());
            ContainerConfig.Register("Customers", new CustomersEntity());
            ContainerConfig.Register("Suppliers", new SuppliersEntity());
            ContainerConfig.Register("Income", new IncomeEntity());
            ContainerConfig.Register("OutCome", new OutComeEntity());
            ContainerConfig.Register("OutComeMaterail", new OutComeMaterailMaterialsEntity());
            ContainerConfig.Register("Damage", new DamageEntity());
           
            ContainerConfig.Register("ConscienceCard", new ConscienceCardEntity());
            ContainerConfig.Register("OutOfConscinesMaterials", new OutOfConsinceMaterialEntity());
            ContainerConfig.Register("BON_LIVRAISON", new BonLivraisonENTITY());
        }
    }
}
