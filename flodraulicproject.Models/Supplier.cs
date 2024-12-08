using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class Supplier
    {

        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string SupplierNo { get; set; }
        public string SupplierType { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Notes { get; set;}
        [ValidateNever]
        public string? ImageUrl { get; set; }

    }
}
