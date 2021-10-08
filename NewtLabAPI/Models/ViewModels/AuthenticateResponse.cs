using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtlabAPI.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string Cedula { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Sector { get; set; }
        public DateTime Nacimiento { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.UserId;
            Username = user.Username;
            Name = user.Name;
            LastName1 = user.LastName1;
            LastName2 = user.LastName2;
            Cedula = user.Cedula;
            Phone = user.Phone;
            Nacimiento = user.Nacimiento;
            Role = user.Role.Description;
            Token = token;
        }
    }
}