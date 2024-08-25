using SMSystem.Core;
using SMSystem.Core.Models;
using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SMSystem.Data
{
    public class CustomersEntity : Data.EF.IDataHelper<Customer>
    {
        // Fileds
        private DBContext db;
        private Customer customers;

        // Methods
        public int Add(Customer table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<Customer>().Add(table);
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
                customers = Find(Id);
                db.Customers.Remove(customers);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Edit(Customer table)
        {
            db = new DBContext();
            if (IsDbConnect())
            {
                db.Set<Customer>().Update(table);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Customer Find(int id)
        {
            db = new DBContext();
            return db.Customers.Where(x => x.Id == id).First();
        }
        public List<Customer> GetData()
        {
            db = new DBContext();
            return db.Customers.ToList();
        }

        public bool IsDbConnect()
        {
            db = new DBContext();
            if (db.Database.CanConnect()) return true; return false;
        }

        public List<Customer> Search(string SearchItem)
        {
            db = new DBContext();
            return db.Customers.Where(x => x.Name.Contains(SearchItem)
            || x.Description.Contains(SearchItem)
            || x.Phone.Contains(SearchItem)
            || x.Location.Contains(SearchItem)
            || x.Email.Contains(SearchItem)
            || x.Phone.Contains(SearchItem)
            || x.Id.ToString() == SearchItem)
                .ToList();
        }
    }
}
