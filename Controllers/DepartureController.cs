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
    [Route("api/controller")]
    public class DepartureController
    {
        private readonly IDepartureRepository _db;
        private ILogger<DepartureController> logger;

        public DepartureController(IDepartureRepository db, ILogger<DepartureController> logger)
        {
            this.logger = logger;
            _db = db;
        }
    }
}
