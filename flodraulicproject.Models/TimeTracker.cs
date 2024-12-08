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
    public class TimeTracker
    {

        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Modified")]
        public DateTime DateModified { get; set; }
        public string? LastModifiedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Worked Performed")]
        public DateTime? DateWorkPerformed {  get; set; }

        public string? JobNumber { get; set; }
        public int FloLocationId { get; set; }
        [ForeignKey("FloLocationId")]
        [ValidateNever]
        public FloLocation FloLocation { get; set; }
        public string? CustomerName { get; set; }
        public int LaborCodeId { get; set; }
        [ForeignKey("LaborCodeId")]
        [ValidateNever]
        public LaborCode LaborCode { get; set; }
        public string? ProjectName { get; set; } 
        public int EngineerId { get; set; }
        [ForeignKey("EngineerId")]
        [ValidateNever]
        public Engineer Engineer { get; set; }
        public string? WorkDescription { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? HrsWorked { get; set; }
        public bool P21Entered { get; set; }
        public bool ClosedEarly { get; set; }
        public string? Notes { get; set;}

    }
}
