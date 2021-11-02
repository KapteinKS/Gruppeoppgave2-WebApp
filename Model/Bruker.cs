using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppeoppgave2_WebApp.Model
{
    public class Bruker
    {
        private int ID { get; set; }

        private bool Admin { get; set; }

        private string Username { get; set; }

        private string Password { get; set; }
    }
}
