using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NewtlabAPI.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [MaxLength(30)]
        public string Description { get; set; }
    }
}
