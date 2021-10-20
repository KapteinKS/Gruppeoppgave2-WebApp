﻿using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using Gruppeoppgave2_WebApp.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace Gruppeoppgave2_WebApp.DAL
{
    public class DepartureRepository : IDepartureRepository
    {
        private readonly TicketContext _db;

        public DepartureRepository(TicketContext db)
        {
            _db = db;
        }


        public async Task<List<Departure>> GetDepartures()
        {
            try
            {
                List<Departure> departures = await _db.Departures.Select(d => new Departure
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

        public async Task UpdateDeparture(Departure departure)
        {
            var toUpdate = await _db.Departures.FindAsync(departure.ID);
            toUpdate.Dep_location = departure.Dep_location;
            toUpdate.Arr_location = departure.Arr_location;
            toUpdate.Dep_time = departure.Dep_time;
            toUpdate.Arr_time = departure.Arr_time;
            toUpdate.Price = departure.Price;
            await _db.SaveChangesAsync();
        }
        public async Task DeleteDeparture(Departure departure)
        {
            var toDelete = await _db.Departures.FindAsync(departure.ID);
            _db.Departures.Remove(toDelete);
            await _db.SaveChangesAsync();
        }
    }
}