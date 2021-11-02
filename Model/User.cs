using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppeoppgave2_WebApp.Model
{
    public class User
    {
        private int UserID { get; set; }

        //[RegularExpression()]
        private string Username { get; set; }
        //[RegularExpression()]
        private string Password { get; set; }
    }
}
