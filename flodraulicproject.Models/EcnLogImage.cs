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
    public class EcnLogImage
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public int EcnLogId { get; set; }
        [ForeignKey("EcnLogId")]
        [ValidateNever]
        public EcnLog EcnLog { get; set; }
    }
}
