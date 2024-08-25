using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using SMSystem.Core.Models;
using System.Text;
using System.Threading.Tasks;

namespace SMSystem.Code
{
    public  class UpdateData
    {
        private Data.EF.IDataHelper<OutCome> _dataHelper;
        private Data.EF.IDataHelper<Income> _dataHelperForIncCome;
        private Data.EF.IDataHelper<Materails> _dataHelperforMaterail;
        private Data.EF.IDataHelper<Customer> _dataHelperforCustomer;
        private Data.EF.IDataHelper<OutComeMaterail> _dataHelperforOutComeMaterials;
        private Data.EF.IDataHelper<Damage> _dataHelperforDamage;
        private Data.EF.IDataHelper<ConscienceCard> _dataHelperforConscincesSelf;
        private Data.EF.IDataHelper<OutOfConscinesMaterials> _dataHelperforOutComConscince;
        private readonly Data.EF.IDataHelper<ConscienceCard> _dataHelperforConscinecCard;
        private Data.EF.IDataHelper<BonLivraison> _dataHelperforbl;
        private Data.EF.IDataHelper<DetailBl> _dataHelperfordetailbl;
        private List<int> MaterialId;
        private Income income;
        private Materails materails;

        public UpdateData()
        {
            _dataHelper = (Data.EF.IDataHelper<OutCome>)ContainerConfig.ObjectType("OutCome");
            _dataHelperforbl = (Data.EF.IDataHelper<BonLivraison>)ContainerConfig.ObjectType("BON_LIVRAISON");
            _dataHelperfordetailbl = (Data.EF.IDataHelper<DetailBl>)ContainerConfig.ObjectType("DETAIL_BL");
            _dataHelperForIncCome = (Data.EF.IDataHelper<Income>)ContainerConfig.ObjectType("Income");
            _dataHelperforMaterail = (Data.EF.IDataHelper<Materails>)ContainerConfig.ObjectType("Materails");
            _dataHelperforCustomer = (Data.EF.IDataHelper<Customer>)ContainerConfig.ObjectType("Customers");
            _dataHelperforOutComeMaterials = (Data.EF.IDataHelper<OutComeMaterail>)ContainerConfig.ObjectType("OutComeMaterail");
            _dataHelperforDamage = (Data.EF.IDataHelper<Damage>)ContainerConfig.ObjectType("Damage");
            _dataHelperforConscincesSelf = (Data.EF.IDataHelper<ConscienceCard>)ContainerConfig.ObjectType("ConscienceCard");
            _dataHelperforOutComConscince = (Data.EF.IDataHelper<OutOfConscinesMaterials>)ContainerConfig.ObjectType("OutOfConscinesMaterials");
            _dataHelperforConscinecCard = (Data.EF.IDataHelper<ConscienceCard>)ContainerConfig.ObjectType("ConscienceCard");
        }

       
        public void UpdateIncome()
        {
            MaterialId = _dataHelperforMaterail.GetData().Select(x => x.Id).ToList();
            for (int i = 0; i < MaterialId.Count; i++)
            {
                var id = MaterialId[i];
                materails = _dataHelperforMaterail.Find(id);
                
                // Get Data
                materails.InCome = _dataHelperForIncCome.GetData().Where(x=>x.MaterailId==id).Select(x => x.Quantity).ToArray().Sum();
                materails.OutCome = _dataHelperforOutComeMaterials.GetData().Where(x=>x.MaterialName==materails.Name).Select(x => x.Quantity).ToArray().Sum();
                materails.Damge=_dataHelperforDamage.GetData().Where(x => x.Name == materails.Name).Select(x => x.Quantity).ToArray().Sum();
                materails.OutConscience = _dataHelperforOutComConscince.GetData().Where(x => x.Name == materails.Name).Select(x => x.Quantity).ToArray().Sum();
                materails.ConscinceCard = _dataHelperforConscinecCard.GetData().Where(x => x.MaterialName == materails.Name).Select(x => x.Quantity).ToArray().Sum();
                // Edit
                _dataHelperforMaterail.Edit(materails);
            }
        }
    }
}
