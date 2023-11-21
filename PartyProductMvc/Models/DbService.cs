using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PartyProductMvc.Models
{
    public class DbService : DbContext
    {
        public DbSet<Party> Parties { get; set; }
        public System.Data.Entity.DbSet<PartyProductMvc.Models.Product> Products { get; set; }
        public DbSet<AssignParty> AssignParties { get; set; }
        public DbSet<ProductRate> ProductRates { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<User> Users { get; set; }
    }
}