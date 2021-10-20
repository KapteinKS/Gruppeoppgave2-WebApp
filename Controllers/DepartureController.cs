using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gruppeoppgave2_WebApp.DAL;
using Gruppeoppgave2_WebApp.Model;
using Microsoft.Extensions.Logging;

namespace Gruppeoppgave2_WebApp.Controllers
{ 
    [Route("api/[controller]")]
    public class DepartureController : ControllerBase
    {
        private readonly IDepartureRepository _db;
        private ILogger<DepartureController> logger;

        public DepartureController(IDepartureRepository db, ILogger<DepartureController> logger)
        {
            this.logger = logger;
            _db = db;
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
            Model.Departure departure = await _db.GetDeparture(id);
            return Ok(departure);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDeparture(Model.Departure departure)
        {
            Boolean ok = await _db.UpdateDeparture(departure);
            return Ok(ok);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDeparture(int id)
        {
            Boolean ok = await _db.DeleteDeparture(id);
            return Ok(ok);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterRoute(Model.Departure departure)
        {
            Boolean ok = await _db.registerRoute(departure);
            return Ok(ok);
        }
    }
}
