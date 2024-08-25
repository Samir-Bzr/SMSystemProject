using SMSystem.Core;
using SMSystem.Core.Models;
using SMSystem.Data;
using SMSystem.Data.Gestproentity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SMSystem.Data.Gestproentity
{
    public class BonLivraisonENTITY : Data.EF.IDataHelper<BonLivraison>
    {
        private DBContextGest db;
        private BonLivraison bonLivraison;

        public BonLivraisonENTITY() => db = new DBContextGest();
        public int Add(BonLivraison table)
        { try
            {
                db = new DBContextGest();
                if (db.Database.CanConnect())
                {
                    db.BonLivraisons.Add(table);
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch
            {
                return 0;
            }
        }

        public int Delete(int Id)
        {
            try
            {

                if (IsDbConnect())
                {
                    bonLivraison = Find(Id);
                    db.BonLivraisons.Remove(bonLivraison);
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch
            {
                return 0;
            }
        }

        public int Edit(BonLivraison table)
        {
            try
            {

                if (db.Database.CanConnect())
                {
                    db = new DBContextGest();
                    db.BonLivraisons.Update(table);
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch
            {
                return 0;
            }
        }

        public BonLivraison Find(int id)
        {
            try
            {

                if (db.Database.CanConnect())
                {

                    return db.BonLivraisons.Where(x => x.IdBl == id).First();
                    
                    
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
        }

           public List<BonLivraison> GetData()
            {
            try
            {

                if (db.Database.CanConnect())
                {

                    return db.BonLivraisons.ToList();


                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
        }

            public bool IsDbConnect()
            {
                db = new DBContextGest();
                if (db.Database.CanConnect()) return true; return false;
            }

            public List<BonLivraison> Search(string SearchItem)
            {
            try
            {

                if (db.Database.CanConnect())
                {

                    return db.BonLivraisons.Where(x => x.IdBl.ToString()== SearchItem 
                    || x.IdClt.ToString().Contains(SearchItem)
                    || x.DateBl.ToString().Contains(SearchItem)
                    ).ToList();

                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
            
        }
        
    }
    
} 


