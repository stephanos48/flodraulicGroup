using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models.ViewModels
{
    public  class OrderVM_Lite
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public double OrderTotal { get; set; }
        public double ListOrderTotal { get; set; }
        public string Price { get; set; }
        public string ListPrice { get; set; }
        public string Savings { get; set; }
        public int Count { get; set; }
        public string PurchaseOrderNo { get; set; }
        public string PartNumber { get; set; }
        public DateTime OrderDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "From Date")]
        public DateOnly FromDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "To Date")]
        public DateOnly ToDate { get; set; }
            
        public string StatusName { get; set; }
        public string PhoneNumber { get; set; }

        public string Name { get; set; }
        public string LocationName { get; set; }
        
    }
}
