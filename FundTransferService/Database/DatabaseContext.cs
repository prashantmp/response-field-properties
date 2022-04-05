using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FundTransferService.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FundTransferService.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customers> Customers { get; set; }
    }
}
