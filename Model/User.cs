using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppeoppgave2_WebApp.Model
{
    [ExcludeFromCodeCoverage]
    public class User
    {
        public int UserID { get; set; }

        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string Username { get; set; }
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$")]
        public string Password { get; set; }
        public byte[] Salt { get; set; }
    }
}
