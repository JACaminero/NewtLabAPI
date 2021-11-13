using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewtlabAPI.Models
{
    public class History
    {
        public int HistoryId { get; set; }
        public string Username { get; set; }
        public string What { get; set; }
        public DateTime Fecha { get { return DateTime.Now; } }
    }
}
