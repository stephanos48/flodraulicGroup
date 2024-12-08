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
    public class FloContact
    {

        [Key]
        public int Id { get; set; }

        [ValidateNever]
        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public int FloLocationId { get; set; }
        [ForeignKey("FloLocationId")]
        [ValidateNever]
        public FloLocation FloLocation { get; set; }

        public string? Notes { get; set; }

    }
}
