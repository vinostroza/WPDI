using Microsoft.AspNetCore.Identity;
using System;

namespace RRHH.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string accountType { get; set; }
    }
}
