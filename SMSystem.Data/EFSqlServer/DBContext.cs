using Microsoft.EntityFrameworkCore;
using SMSystem.Core;
using System;
using SMSystem;
using SMSystem.Core.Models;
    using System.Collections.Generic;
namespace SMSystem.Data.EF
{
    public class DBContext : DbContext
    {

        // Constructores
        public DBContext()
        {
        }
        //Methods -- Override
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var DevelopmentConString = @"Server=SERVER-ZAOUIA;Database=DataBaseSMSSystem;Persist Security Info=True;User Id=dev01;Password=9988;TrustServerCertificate=True;";

            /*try
            {
                var connectionString = "ConString" as string;

                if (!string.IsNullOrEmpty(connectionString))
                {
                    optionsBuilder.UseSqlServer(connectionString);
                }
                else
                {
                    throw new KeyNotFoundException("The key 'ConString' was not found in the configuration.");
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }*/
            optionsBuilder.UseSqlServer(DevelopmentConString);
        }
        // Tables
        //public DbSet<Stores> Stores { get; set; }
        public DbSet<Materails> Materails { get; set; }
        //public DbSet<Customers> Customers { get; set; }
        //public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<OutCome> OutCome { get; set; }
        public DbSet<OutComeMaterail> outComeMaterail { get; set; }
        public DbSet<Damage> Damage { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ConscienceCard> ConscienceCard { get; set; }
        public DbSet<OutOfConscinesMaterials> OutOfConscinesMaterials { get; set; }
    }
}
