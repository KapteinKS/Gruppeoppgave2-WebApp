using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppeoppgave1_WebApp.Model
{
    public class Departure
    {
        public int ID { get; set; }
        public string Dep_location { get; set; }

        public string Arr_location { get; set; }

        public string Dep_time { get; set; }

        public string Arr_time { get; set; }
        public int Price { get; set; }
    }
}
