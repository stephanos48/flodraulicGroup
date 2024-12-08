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
    public class EngineeringLogImage
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public int EngineeringLogId { get; set; }
        [ForeignKey("EngineeringLogId")]
        [ValidateNever]
        public EngineeringLog EngineeringLog { get; set; }
    }
}
