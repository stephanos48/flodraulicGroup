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
    public class HotlistImage
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public int HotlistId { get; set; }
        [ForeignKey("HotlistId")]
        [ValidateNever]
        public Hotlist Hotlist { get; set; }
    }
}
