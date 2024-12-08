using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models.ViewModels
{
    public class InitialQuoteReviewVM
    {
        public InitialQuoteReview InitialQuoteReview { get; set; }
        public EngineeringLog EngineeringLog { get; set; }
        public int Id { get; set; } 
        public string QuoteNo { get; set; }
        public string Customer { get; set; }
        public string SystemDescription { get; set; }
        public DateTime? QuoteReceivedDate { get; set; }

        public DateTime? QuoteTargetDate { get; set; }
        public string? SalesPerson { get; set; }
        public string? SalesLocationName { get; set; }
        public bool FGIForm { get; set; }
        public bool FGIFormDetail { get; set; }
        public bool MeetCustomerDate { get; set; }
        public bool CustomerWaitToTarget { get; set; }
        public bool CustomerSpecsReq { get; set; }
        public bool FallWithinFGICapability { get; set; }

        public bool ConfirmFGIForm { get; set; }

        public string? SystemType { get; set; }

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
