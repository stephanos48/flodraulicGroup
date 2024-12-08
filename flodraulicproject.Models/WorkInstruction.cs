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
    public class WorkInstruction
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string WIName { get; set; }

        public string? WIType { get; set; }

        [ValidateNever]
        public string? ImageUrl { get; set; }

    }
}
