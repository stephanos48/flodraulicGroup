﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class ShippedQty
    {

        [Key]
        public int Id { get; set; }

        [ValidateNever]
        public string? PartNumber { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
        [ValidateNever]
        public string? LocationName { get; set; }

        public int FloLocationId { get; set; }
        [ForeignKey("FloLocationId")]
        [ValidateNever]
        public FloLocation FloLocation { get; set; }

        public int QtyShipped { get; set; }
        public int OrderNoId { get; set; }
        public DateTime? ShipDate { get; set; }

    }
}