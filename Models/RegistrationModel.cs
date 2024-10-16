using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationApplication.Models
{
    public class RegistrationModel
    {
        // attributes to transfer data from controller.js to cs
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int phoneNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


    }
}