using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class SupplierContact
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContactName { get; set; }
        public string OfficeLocation { get; set; }
        public string Cell { get; set; }
        public string Email {  get; set; }
        public string Notes { get; set;}
        [ValidateNever]
        public string? ImageUrl { get; set; }

    }
}
