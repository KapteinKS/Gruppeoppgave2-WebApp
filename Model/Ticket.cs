using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppeoppgave1_WebApp.Model
{
    public class Ticket
    {
        public string Route { get; set; }

        public string LeaveDate { get; set; }

        public string HomeDate { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[0-9a-zA-ZæøåÆØÅ. \-]{2,50}$")]
        public string LastName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$")]
        public string Email { get; set; }

        [RegularExpression(@"^[0-9]{8}$")]
        public string Phone { get; set; }

        public int Price { get; set; }

        public int Passengers { get; set; }
    }
}
