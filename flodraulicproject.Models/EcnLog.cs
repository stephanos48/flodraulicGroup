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
    public class EcnLog
    {
        [Key]
        public int Id { get; set; }

        public int EcnLogStatusId { get; set; }
        [ForeignKey("EcnLogStatusId")]
        [ValidateNever]
        public EcnLogStatus EcnLogStatus { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "DateCreated")]
        public DateTime? DateCreated { get; set; }

        public string? CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "EcnRequestDate")]
        public DateTime? EcnRequestDate { get; set; }

        public int EngineeringLogId { get; set; }
        [ForeignKey("EngineeringLogId")]
        [ValidateNever]
        public EngineeringLog EngineeringLog { get; set; }

        public string? Reason { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? CostImpact { get; set; }

        public bool AffectPrice { get; set; }

        public string? CustomerApprovalReq { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ECNAddlEngHrs { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ECNAddlShopHrs { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PCNAddlEngHrs { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? PCNAddlShopHrs { get; set; }

        public string? RespToProcess { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "ECN Completion Date")]
        public DateTime? EcnCompletionDate { get; set; }

        public string? Notes { get; set; }

        [ValidateNever]
        public List<EcnLogImage> EcnLogImages { get; set; }

    }
}
