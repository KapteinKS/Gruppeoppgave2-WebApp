using Gruppeoppgave2_WebApp.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppeoppgave2_WebApp.DAL
{
    [ExcludeFromCodeCoverage]
    public class InitDB
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TicketContext>();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var departure1 = new Departures
                {
                    Dep_location = "Oslo",
                    Arr_location = "Kiel",
                    Dep_time = "14:00",
                    Arr_time = "18:00",
                    Price = 128
                };

                var departure2 = new Departures
                {
                    Dep_location = "Larvik",
                    Arr_location = "Strømstad",
                    Dep_time = "13:30",
                    Arr_time = "17:40",
                    Price = 256
                };

                string noHashPw = "admin69";
                byte[] salt = DepartureRepository.CreateSalt();
                byte[] hashedPw = DepartureRepository.CreateHash(noHashPw, salt);
                var str = System.Text.Encoding.Default.GetString(hashedPw);
                var user1 = new Model.User
                {
                    Username = "Admin",
                    Salt = salt,
                    Password = str
                };

                Console.WriteLine(user1.Password);

                context.Add(departure1);
                context.Add(departure2);
                context.Add(user1);
                context.SaveChanges();
            }
        }
    }
}
