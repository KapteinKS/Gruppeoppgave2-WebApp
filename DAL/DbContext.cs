using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Gruppeoppgave1_WebApp.DAL
{
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
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Departures> Departures { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
