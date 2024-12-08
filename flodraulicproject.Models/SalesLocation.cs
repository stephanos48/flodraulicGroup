using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class SalesLocation
    {

        [Key]
        public int Id { get; set; }
        public string? SalesLocationName { get; set; }
        public string? Notes { get; set; }

    }
}
