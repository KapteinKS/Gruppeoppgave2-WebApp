using System.Threading.Tasks;
using System.Collections.Generic;
using Gruppeoppgave2_WebApp.Model;

namespace Gruppeoppgave2_WebApp.DAL
{
    public interface IDepartureRepository
    {
        Task<List<Departure>> GetDepartures();
        Task UpdateDeparture(Departure departure);
        Task DeleteDeparture(Departure departure);
    }
}