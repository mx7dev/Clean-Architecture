using Microsoft.EntityFrameworkCore;
using NorthWind.EFCore.DataContexts.POCOEntities;
using NorthWind.Sales.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.EFCore.DataContexts
{
    public class NorthWindOrderContext : DbContext
    {
        public NorthWindOrderContext( DbContextOptions<NorthWindOrderContext> options) : base(options) { }

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
