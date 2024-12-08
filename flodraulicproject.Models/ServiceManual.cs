using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class ServiceManual
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string ManualName { get; set; }

        public string? ManualType { get; set; }

        [ValidateNever]
        public string? ImageUrl { get; set; }

    }
}
