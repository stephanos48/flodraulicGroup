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
    public class Hotlist
    {

        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }

        public string? CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Modified")]
        public DateTime? DateModified { get; set; }

        public string? ModifiedBy { get; set; }

        public string? ReportedBy { get; set; }

        public string? Coordinator { get; set; }

        public int EngineerId { get; set; }
        [ForeignKey("EngineerId")]
        [ValidateNever]
        public Engineer Engineer { get; set; }

        public int IssueCategoryId { get; set; }
        [ForeignKey("IssueCategoryId")]
        [ValidateNever]
        public IssueCategory IssueCategory { get; set; }

        public int HotlistRespId { get; set; }
        [ForeignKey("HotlistRespId")]
        [ValidateNever]
        public HotlistResp HotlistResp { get; set; }

        public string? JobNumber { get; set; }

        public string? Customer { get; set; }

        public string? IssueDescription { get; set;}

        public double? HrsLost { get; set; }

        public double? TotalDollarsLost { get; set; }

        public bool WorkStoppage { get; set; }

        public int HotlistStatusId { get; set; }
        [ForeignKey("HotlistStatusId")]
        [ValidateNever]
        public HotlistStatus HotlistStatus{ get; set; }

        [ValidateNever]
        public List<HotlistImage> HotlistImages { get; set; }

        public ICollection<HotlistComment> HotlistComments { get; }

        public string? Notes { get; set; }
    }
}
