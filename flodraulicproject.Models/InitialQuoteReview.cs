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
    public class InitialQuoteReview
    {

        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "DateCreated")]
        public DateTime? DateCreated { get; set; }

        public string? CreatedBy { get; set; }

        public int EngineeringLogId { get; set; }
        [ForeignKey("EngineeringLogId")]
        [ValidateNever]
        public EngineeringLog EngineeringLog { get; set; }

        public bool FGIForm { get; set; }

        public bool FGIFormDetail { get; set; }

        public bool MeetCustomerDate { get; set; }

        public bool CustomerWaitToTarget { get; set; }

        public bool CustomerSpecsReq { get; set; }

        public bool FallWithinFGICapability { get; set; }

        public bool ConfirmFGIForm { get; set; }

        public string? SystemType {  get; set; }

        public string? SimilarJob { get; set; }

        public string? Concerns { get; set; }

        public string? Suggestions { get; set; }

        public string? Engineer { get; set; }

        public bool IntiateQuote { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Initial Quote Completion Date")]
        public DateTime? InitialQuoteCompletionDate { get; set; }

        public string? Notes { get; set; }

    }
}
