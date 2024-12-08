using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models.ViewModels
{
    public class EngLogVM1
    {

        public int Id {  get; set; }
        public string JobNumber { get; set; }
        public string QuoteNo { get; set; }
        public string Customer { get; set; }
        public string SystemDescription { get; set; }
        public int? Qty { get; set; }
        public decimal? QuotedEngHrs { get; set; }
        public decimal? ActualEngHrs { get; set; }
        public string SalesLocationName { get; set; }
        public string MfgLocationName { get; set; }
        public string EstimatorName { get; set; }
        public string EngineerName { get; set; }
        public string LogStatusName { get; set; }
        public string Notes { get; set; }


        public DateTime? QuoteReceivedDate { get; set; }
        public DateTime? QuoteTargetDate { get; set; }
        public DateTime? InitialQuoteReviewTargetDate { get; set; }
        public DateTime? InitialQuoteReviewDate { get; set; }
        public DateTime? FinalQuoteReviewTargetDate { get; set; }
        public DateTime? FinalQuoteReviewDate { get; set; }
        public DateTime? QuoteDate { get; set; }

        public DateTime? KickOffTD { get; set; }
        public DateTime? KickOffD { get; set; }
        public DateTime? FinancialReviewTargetDate { get; set; }
        public DateTime? FinancialReviewDate { get; set; }
        public DateTime? InitialDesignReviewTargetDate { get; set; }
        public DateTime? InitialDesignReviewDate { get; set; }
        public DateTime? FinalDesignReviewTargetDate { get; set; }
        public DateTime? FinalDesignReviewDate { get; set; }
        public DateTime? ShopReleaseTargetDate { get; set; }
        public DateTime? ShopReleaseDate { get; set; }
        public IEnumerable<EngineeringLog> EngineeringLogs { get; set; }
        public EngineeringLog EngineeringLog { get; set; }
    }
}
