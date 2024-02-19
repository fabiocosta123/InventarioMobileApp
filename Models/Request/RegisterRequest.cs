using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioMobileApp.Models.Request
{
     public class RegisterRequest
    {
        public RegisterRequest(string email, string password)
        {
            Email = email;
            Password = password;

        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
