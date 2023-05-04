using hahn.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Domain.Entities
{
    public class ApplicationUser : IdentityUser<string>
    {
        public string Name { get; set; }
        public eUserType UserType { get; set; }
        [NotMapped]
        public string Password { get; set; }


    }
}
