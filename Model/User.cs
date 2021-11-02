using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppeoppgave2_WebApp.Model
{
    public class User
    {
        public int UserID { get; set; }

        //[RegularExpression()]
        public string Username { get; set; }
        //[RegularExpression()]
        public string Password { get; set; }
    }
}
