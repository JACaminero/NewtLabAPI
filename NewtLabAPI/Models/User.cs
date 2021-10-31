using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewtlabAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(200)]
        public string Username { get; set; }
        [MaxLength(20)]
        public string Password { get; set; }
        public Role Role { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }
        [MaxLength(300)]
        public string LastName1 { get; set; }
        [MaxLength(300)]
        public string LastName2 { get; set; }
        [MaxLength(300)]
        public string Cedula { get; set; }
        [MaxLength(300)]
        public string Phone { get; set; }
        [MaxLength(300)]
        public string Street { get; set; }
        [MaxLength(300)]
        public string HouseNumber { get; set; }
        [MaxLength(300)]
        public string Grado { get; set; }
        public string Seccion { get; set; }
        [MaxLength(300)]
        public string Sector { get; set; }
        public DateTime Nacimiento { get; set; }
        public bool IsOn { get; set; }
        [NotMapped]
        public string Matricula { 
            get {
                return $"{Name[0]}{LastName1[0]}{LastName2[0]}{Nacimiento.Year}{Nacimiento.Month}"; 
            } 
        }
    }
}
