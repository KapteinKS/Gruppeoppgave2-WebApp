using System.Threading.Tasks;
using System.Collections.Generic;
using Gruppeoppgave2_WebApp.Model;

namespace Gruppeoppgave2_WebApp.DAL
{
    public interface IDepartureRepository
    {
        Task<List<User>> GetUsers();
        Task<List<Departure>> GetDepartures();
        Task<Departure> GetDeparture(int id);
        Task<bool> UpdateDeparture(Departure departure);
        Task<bool> DeleteDeparture(int id);
        Task<bool> registerRoute(Departure departure);
    }
}