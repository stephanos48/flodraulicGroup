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
    public class Product
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string PartNumber { get; set; }
        public string Description { get; set; }

        [Display(Name = "List Price")]
        [Range(1,1000)]
        public double ListPrice { get; set; }

        public int Qoh { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        public int PartFamilyId { get; set; }

        [ForeignKey("PartFamilyId")]
        [ValidateNever]
        public PartFamily PartFamily { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

    }
}
