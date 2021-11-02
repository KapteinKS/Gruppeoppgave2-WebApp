using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gruppeoppgave2_WebApp.DAL;
using Gruppeoppgave2_WebApp.Model;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Gruppeoppgave2_WebApp.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class DepartureController : ControllerBase
    {
        private readonly IDepartureRepository _db;
        private ILogger<DepartureController> logger;

        //Session variable 
        /*
        private const string _loggetInn = "loggetInn";
        */
        

        public DepartureController(IDepartureRepository db, ILogger<DepartureController> logger)
        {
            this.logger = logger;
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            List<Model.User> users = await _db.GetUsers();
            return Ok(users);
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartures()
        {
            List<Model.Departure> departures = await _db.GetDepartures();
            return Ok(departures);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDeparture(int id)
        {
            if (ModelState.IsValid)
            {
                Model.Departure departure = await _db.GetDeparture(id);
                if(departure == null)
                {
                    logger.LogInformation("Departure not found");
                    return NotFound();
                }
                return Ok(departure);
            }
            logger.LogInformation("Bad request");
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDeparture(Model.Departure departure)
        {
            if (ModelState.IsValid)
            {
                Boolean ok = await _db.UpdateDeparture(departure);
                if (!ok)
                {
                    logger.LogInformation("Changes could not be made");
                    return NotFound();
                }
                logger.LogInformation("Departure updated");
                return Ok(ok);
            }
            logger.LogInformation("ModelState invalid");
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeparture(int id)
        {
            Boolean ok = await _db.DeleteDeparture(id);
            if (!ok)
            {
                logger.LogInformation("Departure not deleted");
                return NotFound();
            }
            logger.LogInformation("Departure deleted");
            return Ok(ok);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterRoute(Model.Departure departure)
        {
            if(ModelState.IsValid)
            {
                Boolean ok = await _db.RegisterRoute(departure);
                if (!ok)
                {
                    logger.LogInformation("Could not save departure");
                    return BadRequest();
                }
                logger.LogInformation("New departure added");
                return Ok();
            }
            logger.LogInformation("Bad Request");
            return BadRequest();
        }
        /*
        public async Task<ActionResult> LoggInn(Bruker bruker)
        {
            
        }
        */
    }
}
