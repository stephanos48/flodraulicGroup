using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class CustomerLocation
    {

        public int CustomerLocationId { get; set; }
        public string LocationName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? Notes { get; set; }

    }
}
