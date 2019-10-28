using InformationKiosk.DataProtocol;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationKiosk.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<IceCream> IceCreams { get; set; }
    }
}
