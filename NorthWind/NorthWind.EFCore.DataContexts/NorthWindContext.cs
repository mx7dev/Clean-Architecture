using Microsoft.EntityFrameworkCore;
using NorthWind.EFCore.DataContexts.POCOEntities;
using NorthWind.Entities.POCOEntities;
using NorthWind.Sales.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.EFCore.DataContexts
{

    public class NorthWindContext: DbContext
    {

        protected override void OnConfiguring(
           DbContextOptionsBuilder optionsBuilder
            )
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NorthWindDB");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Log> Logs => Set<Log>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
