using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using Gruppeoppgave2_WebApp.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace Gruppeoppgave2_WebApp.DAL
{
    public class DepartureRepository : IDepartureRepository
    {
        private readonly TicketContext _db;

        public DepartureRepository(TicketContext db)
        {
            _db = db;
        }


        public async Task<List<Model.User>> GetUsers()
        {
            try
            {
                List<Model.User> users = await _db.Users.Select(u => new Model.User
                {
                    UserID = u.UserID,
                    Username = u.Username,
                    Password = u.Password

                }).ToListAsync();
                return users;
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

        public async Task<Model.Departure> GetDeparture(int id)
        {
            var departure = await _db.Departures.FindAsync(id);

            return new Model.Departure
            {
                ID = departure.DepID,
                Dep_location = departure.Dep_location,
                Arr_location = departure.Arr_location,
                Dep_time = departure.Dep_time,
                Arr_time = departure.Arr_time,
                Price = departure.Price
            };
        }

        public async Task<Boolean> UpdateDeparture(Model.Departure departure)
        {
            try
            {
                Debug.WriteLine(departure.ID);
                var toUpdate = await _db.Departures.FindAsync(departure.ID);
                toUpdate.Dep_location = departure.Dep_location;
                toUpdate.Arr_location = departure.Arr_location;
                toUpdate.Dep_time = departure.Dep_time;
                toUpdate.Arr_time = departure.Arr_time;
                toUpdate.Price = departure.Price;
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Boolean> DeleteDeparture(int id)
        {
            try
            {
                var toDelete = await _db.Departures.FindAsync(id);
                _db.Departures.Remove(toDelete);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Boolean> RegisterRoute(Model.Departure departure)
        {
            try
            {
                var dep = new Departures
                {
                    Dep_location = departure.Dep_location,
                    Arr_location = departure.Arr_location,
                    Dep_time = departure.Dep_time,
                    Arr_time = departure.Arr_time,
                    Price = departure.Price
                };
                _db.Departures.Add(dep);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
