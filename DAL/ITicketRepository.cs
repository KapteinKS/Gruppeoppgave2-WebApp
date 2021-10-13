using Gruppeoppgave1_WebApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppeoppgave1_WebApp.DAL
{
    public interface ITicketRepository
    {
        Task<bool> OrderTicket(Ticket orderedTicket);
        Task<List<Ticket>> GetTickets();
        Task<List<Departure>> GetDepartures();
    }
}
