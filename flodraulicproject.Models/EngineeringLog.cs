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
    public class EngineeringLog
    {

        public int Id { get; set; }

        public string? JobNumber { get; set; }

        public string? Customer { get; set; }

        public string? SystemDescription { get; set; }
        public int LogStatusId { get; set; }
        [ForeignKey("LogStatusId")]
        [ValidateNever]
        public LogStatus LogStatus { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }

        public string? CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Modified")]
        public DateTime? DateModified { get; set; }

        public string? LastModifiedBy { get; set; }
        public string? QuoteNo { get; set; }
        public string? HistoricQuoteNo { get; set; }

        public int MfgLocationId { get; set; }
        [ForeignKey("MfgLocationId")]
        [ValidateNever]
        public MfgLocation MfgLocation { get; set; }

        public int SalesLocationId { get; set; }
        [ForeignKey("SalesLocationId")]
        [ValidateNever]
        public SalesLocation SalesLocation { get; set; }

        public string? SalesPerson { get; set; }
        public int? Qty { get; set; }

        public int EstimatorId { get; set; }
        [ForeignKey("EstimatorId")]
        [ValidateNever]
        public Estimator Estimator { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "QuoteRequestReceivedDate")]
        public DateTime? QuoteRequestReceivedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "QuoteTargetDate")]
        public DateTime? QuoteTargetDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "QuoteDate")]
        public DateTime? QuoteDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "InitialQuoteReviewTargetDate")]
        public DateTime? InitialQuoteReviewTargetDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "InitialQuoteReviewDate")]
        public DateTime? InitialQuoteReviewDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "FinalQuoteReviewTargetDate")]
        public DateTime? FinalQuoteReviewTargetDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "FinalQuoteReviewDate")]
        public DateTime? FinalQuoteReviewDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "OrderDate")]
        public DateTime? OrderDate { get; set; }

        public string? CustomerPoNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "PromiseDate")]
        public DateTime? PromiseDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "MIPTargetDate")]
        public DateTime? MIPTargetDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "MIPDate")]
        public DateTime? MIPDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ContractReviewTargetDate")]
        public DateTime? ContractReviewTargetDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ContractReviewDate")]
        public DateTime? ContractReviewDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "OrderEntryTargetDate")]
        public DateTime? OrderEntryTargetDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "OrderEntryDate")]
        public DateTime? OrderEntryDate { get; set; }

        public int EngineerId { get; set; }
        [ForeignKey("EngineerId")]
        [ValidateNever]
        public Engineer Engineer { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "KickOffTargetDate")]
        public DateTime? KickOffTargetDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "KickOffDate")]
        public DateTime? KickOffDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "FinancialReviewTargetDate")]
        public DateTime? FinancialReviewTargetDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "FinancialReviewDate")]
        public DateTime? FinancialReviewDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "InitialDesignReviewTargetDate")]
        public DateTime? InitialDesignReviewTargetDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "InitialDesignReviewDate")]
        public DateTime? InitialDesignReviewDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "FinalDesignReviewTargetDate")]
        public DateTime? FinalDesignReviewTargetDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "FinalDesignReviewDate")]
        public DateTime? FinalDesignReviewDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ShopReleaseTargetDate")]
        public DateTime? ShopReleaseTargetDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ShopReleaseDate")]
        public DateTime? ShopReleaseDate { get; set; }

        public bool RedlineNeeded { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "RedlineCompletionDate")]
        public DateTime? RedlineCompletionDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? QuotedEngHrs { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? QuotedShopHrs { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ActualEngHrs { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ActualShopHrs { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? EngEff { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ShopEff { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalCost { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? QuoteValue { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "TargetShipDate")]
        public DateOnly? TargetShipDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ActualShipDate")]
        public DateOnly? ActualShipDate { get; set; }
        public bool QuotedOT { get; set; }
        public bool MIPOT { get; set; }
        public bool DesignOT { get; set; }
        public bool ShipOT { get; set; }
        public string? Notes { get; set; }
        public ICollection<EngLogComment> EngLogComments { get; } = new List<EngLogComment>();
        [ValidateNever]
        public List<EngineeringLogImage> EngineeringLogImages { get; set; }
        
    }
}
