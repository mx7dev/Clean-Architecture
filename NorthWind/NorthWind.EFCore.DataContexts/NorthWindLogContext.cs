using Microsoft.EntityFrameworkCore;
using NorthWind.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.EFCore.DataContexts
{
    public class NorthWindLogContext : DbContext
    {
        public NorthWindLogContext(
            DbContextOptions<NorthWindLogContext> options) : base(options) { }

        public DbSet<Log> Logs { get; set; }


    }
}
