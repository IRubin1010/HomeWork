using InformationKiosk.BE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<IceCream> IceCreams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString);
            }
        }
    }
}
