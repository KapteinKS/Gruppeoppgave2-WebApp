using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gruppeoppgave1_WebApp.DAL;
using Gruppeoppgave1_WebApp.Model;
using Microsoft.Extensions.Logging;

namespace Gruppeoppgave1_WebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _db;
        private ILogger<TicketController> logger;

        public TicketController(ITicketRepository db, ILogger<TicketController> logger)
        {
            this.logger = logger;
            _db = db;
        }

        public async Task<ActionResult> OrderTicket(Ticket orderedTicket)
        {
            bool returnOK = await _db.OrderTicket(orderedTicket);
            if (!returnOK)
            {
                logger.LogInformation("Ticket could not be saved");
                return BadRequest("Ticket could not be saved");
            }
            return Ok("Your ticket has been ordered");
        }

        public async Task<ActionResult> GetTickets()
        {
            List<Ticket> tickets = await _db.GetTickets();
            return Ok(tickets);
        }

        public async Task<ActionResult> GetDepartures()
        {
            List<Departure> departures = await _db.GetDepartures();
            return Ok(departures);
        }
    }
}
