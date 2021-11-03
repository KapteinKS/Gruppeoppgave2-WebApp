using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Gruppeoppgave2_WebApp.DAL
{
    [ExcludeFromCodeCoverage]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual List<Order> Orders { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string Route { get; set; }
        public string LeaveDate { get; set; }
        public string HomeDate { get; set; }
        public int Price { get; set; }
        public int Passengers { get; set; }
    }

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
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Departures> Departures { get; set; }
        public DbSet<Model.User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
