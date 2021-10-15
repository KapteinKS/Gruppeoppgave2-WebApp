using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gruppeoppgave1_WebApp.DAL;
using Gruppeoppgave1_WebApp.Model;
using Microsoft.Extensions.Logging;

namespace Gruppeoppgave2_WebApp.Controllers
{
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _db;
        private ILogger<TicketController> logger;

        public TicketController(ITicketRepository db, ILogger<TicketController> logger)
        {
            this.logger = logger;
            _db = db;
        }

        //Unnecessary in current version
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

        //Unnecessary in current version
        public async Task<ActionResult> GetTickets()
        {
            List<Ticket> tickets = await _db.GetTickets();
            return Ok(tickets);
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartures()
        {
            List<Departure> departures = await _db.GetDepartures();
            return Ok(departures);
        }

        [HttpPut]
        public async Task UpdateDeparture(Departure departure)
        {
            await _db.UpdateDeparture(departure);
        }

        [HttpDelete]
        public async Task DeleteDeparture(Departure departure)
        {
            await _db.DeleteDeparture(departure);
        }
    }
}
