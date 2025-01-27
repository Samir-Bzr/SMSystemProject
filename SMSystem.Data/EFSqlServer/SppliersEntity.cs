﻿using SMSystem.Core;
using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SMSystem.Data
{
    public class SuppliersEntity : Data.EF.IDataHelper<Supplier>
    {
        // Fileds
        private DBContext db;
        private Supplier suppliers;

        // Methods
        public int Add(Supplier table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<Supplier>().Add(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Delete(int Id)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                suppliers = Find(Id);
                db.Suppliers.Remove(suppliers);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(Supplier table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<Supplier>().Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Supplier Find(int id)
        {
            db = new DBContext();
            return db.Suppliers.Where(x => x.Id == id).First();
        }
        public List<Supplier> GetData()
        {
            db = new DBContext();
            return db.Suppliers.ToList();
        }

        public bool IsDbConnect()
        {
            db = new DBContext();
            if (db.Database.CanConnect()) return true; return false;
        }

        public List<Supplier> Search(string SearchItem)
        {
            db = new DBContext();
            return db.Suppliers.Where(x => x.Name.Contains(SearchItem)
             || x.Description.Contains(SearchItem)
            || x.Phone.Contains(SearchItem)
            || x.location.Contains(SearchItem)
            || x.Email.Contains(SearchItem)
            || x.Phone.Contains(SearchItem)
            || x.Id.ToString() == SearchItem)
                .ToList();
        }
    }
}
