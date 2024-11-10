using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Project02_MovieWebsite.Models
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base("MyConnectionString") { }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Genres> Genres { get; set; }
    }
}