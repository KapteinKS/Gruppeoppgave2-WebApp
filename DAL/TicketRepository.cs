﻿using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using Gruppeoppgave2_WebApp.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Gruppeoppgave2_WebApp.DAL
{
    /*
    [ExcludeFromCodeCoverage]
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketContext _db;
        
        public TicketRepository(TicketContext db)
        {
            _db = db;
        }

        
        public async Task<bool> OrderTicket(Ticket orderedTicket)
        {
            try
            {
                var order = new Order()
                {
                    Route = orderedTicket.Route,
                    LeaveDate = orderedTicket.LeaveDate,
                    HomeDate = orderedTicket.HomeDate,
                    Price = orderedTicket.Price,
                    Passengers = orderedTicket.Passengers
                };

                string email = orderedTicket.Email;
                List<Customer> customers = await _db.Customers.Select(c => new Customer
                {
                    CustomerID = c.CustomerID,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    Phone = c.Phone,
                    Orders = c.Orders
                }).ToListAsync();

                Customer c = await _db.Customers.FirstOrDefaultAsync(c => c.Email == orderedTicket.Email);
                
                if (c == null)
                {
                    Console.WriteLine("New customer");
                    
                    var customer = new Customer
                    {
                        FirstName = orderedTicket.FirstName,
                        LastName = orderedTicket.LastName,
                        Email = orderedTicket.Email,
                        Phone = orderedTicket.Phone
                    };
                    customer.Orders = new List<Order>();
                    customer.Orders.Add(order);
                    _db.Customers.Add(customer);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("Existing customer");
                    c.Orders.Add(order);
                    await _db.SaveChangesAsync();
                }
                return true;
            }
            catch
            {
                Console.WriteLine("CRASH");
                return false;
            }
        }

        //Method for retrieving all orders
        public async Task<List<Ticket>> GetTickets()
        {
            Console.WriteLine("Getting tickets");
            try
            {
                List<Customer> customers = await _db.Customers.Select(c => new Customer
                {
                    CustomerID = c.CustomerID,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    Phone = c.Phone,
                    Orders = c.Orders
                }).ToListAsync();
                List<Ticket> orders = new List<Ticket>();
                foreach (var customer in customers)
                {
                    foreach (var order in customer.Orders)
                    {
                        var anOrder = new Ticket
                        {
                            FirstName = customer.FirstName,
                            LastName = customer.LastName,
                            Email = customer.Email,
                            Phone = customer.Phone,
                            Route = order.Route,
                            LeaveDate = order.LeaveDate,
                            HomeDate = order.HomeDate,
                            Passengers = order.Passengers,
                            Price = order.Price
                        };
                        orders.Add(anOrder);
                    }
                }
                return orders;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Model.Departure>> GetDepartures()
        {
            try
            {
                List<Model.Departure> departures = await _db.Departures.Select(d => new Model.Departure
                {
                    ID = d.DepID,
                    Dep_location = d.Dep_location,
                    Arr_location = d.Arr_location,
                    Dep_time = d.Dep_time,
                    Arr_time = d.Arr_time,
                    Price = d.Price
                }).ToListAsync();
                return departures;
            }
            catch
            {
                return null;
            }
        }

        public async Task UpdateDeparture(Model.Departure departure)
        {
            var toUpdate = await _db.Departures.FindAsync(departure.ID);
            toUpdate.Dep_location = departure.Dep_location;
            toUpdate.Arr_location = departure.Arr_location;
            toUpdate.Dep_time = departure.Dep_time;
            toUpdate.Arr_time = departure.Arr_time;
            toUpdate.Price = departure.Price;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteDeparture(Model.Departure departure)
        {
            var toDelete = await _db.Departures.FindAsync(departure.ID);
            _db.Departures.Remove(toDelete);
            await _db.SaveChangesAsync();
        }
    }
    */
}
