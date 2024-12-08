using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models.ViewModels
{
    public class PartQohVM
    {

        public string? LocationName { get; set; }
        public string? PartNumber { get; set; }
        public string? Description { get; set; }
        public string? FamilyName { get; set; }
        public int? Id { get; set; }
        public int? Qoh { get; set; }
        public double? ListPrice { get; set; }

    }
}
