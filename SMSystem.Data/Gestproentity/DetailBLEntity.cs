using SMSystem.Core;
using SMSystem.Core.Models;
using SMSystem.Data;
using SMSystem.Data.Gestproentity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SMSystem.Data.Gestproentity
{
    public class DetailBLEntity : Data.EF.IDataHelper<DetailBl>
    {
        public DBContextGest db;
        public DetailBl detailBl;
        public int Add(DetailBl table)
        {
            try
            {
                db = new DBContextGest();
                if (db.Database.CanConnect())
                {
                    db.DetailBls.Add(table);
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
                    detailBl = Find(Id);
                    db.DetailBls.Remove(detailBl);
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

        public int Edit(DetailBl table)
        {
            try
            {

                if (db.Database.CanConnect())
                {
                    db = new DBContextGest();
                    db.DetailBls.Update(table);
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

        public DetailBl Find(int id)
        {
            try
            {

                if (db.Database.CanConnect())
                {

                    return db.DetailBls.Where(x => x.IdBl == id).First();


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

        public List<DetailBl> GetData()
        {
            try
            {

                if (db.Database.CanConnect())
                {

                    return db.DetailBls.ToList();


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

        public List<DetailBl> Search(string SearchItem)
        {
            try
            {

                if (db.Database.CanConnect())
                {

                    return db.DetailBls.Where(x => x.IdBl.ToString() == SearchItem
                    || x.RefArtFini.ToString().Contains(SearchItem)
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
