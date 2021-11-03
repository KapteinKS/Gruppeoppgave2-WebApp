using System.Threading.Tasks;
using System.Collections.Generic;
using Gruppeoppgave2_WebApp.Model;

namespace Gruppeoppgave2_WebApp.DAL
{
    public interface IDepartureRepository
    {
        Task<List<Model.User>> GetUsers();
        Task<List<Model.Departure>> GetDepartures();
        Task<Model.Departure> GetDeparture(int id);
        Task<bool> UpdateDeparture(Model.Departure departure);
        Task<bool> DeleteDeparture(int id);
        Task<bool> RegisterRoute(Model.Departure departure);
        Task<bool> LogIn(Model.User user);
    }
}