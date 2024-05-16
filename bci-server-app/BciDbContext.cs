using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.SqlServer;

using bci_server_app.Model;

namespace bci_server_app.Context
{
    public class BciDbContext : DbContext
    {

        public BciDbContext(DbContextOptions<BciDbContext> options) : base(options)
        {}
        public DbSet<Item> Items { get; set; }
    }
}