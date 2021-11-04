using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Gruppeoppgave2_WebApp.DAL
{
    [ExcludeFromCodeCoverage]
    public class Departures
    {
        [Key]
        public int DepID { get; set; }
        public string Dep_location { get; set; }
        public string Arr_location { get; set; }
        public string Dep_time { get; set; }
        public string Arr_time { get; set; }
        public int Price { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }

        public byte[] Salt { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class DepartureContext : DbContext
    {
        public DepartureContext(DbContextOptions<DepartureContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Departures> Departures { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
