using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models.ViewModels
{
    public class TimeTrackerVM1
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
        [Display(Name = "Date Work Performed")]
        public DateTime? DateWorkPerformed { get; set; }
        public string? JobNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? LocationName { get; set; }
        public string? LaborCodeName { get; set; }
        public string? ProjectName { get; set; }
        public string? Name { get; set; }
        public string? WorkDescription { get; set; }
        public decimal? HrsWorked { get; set; }
        public bool P21Entered { get; set; }
        public bool ClosedEarly { get; set; }
        public string? Notes { get; set; }
        public string? ImageUrl { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "From Date")]
        public DateTime? FromDate { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "To Date")]
        public DateTime? ToDate { get; set; }
        public IEnumerable<Engineer> Engineers { get; set; }

        public int EngineerId { get; set; }
        [ForeignKey("EngineerId")]
        [ValidateNever]
        public Engineer Engineer { get; set; }

        public int OpenProjects { get; set; }
        public int OpenProjectsOverHrs { get; set; }

        public decimal? QuotedEngHrs { get; set; }
        public string CurrentOpenEff { get; set; }
        public decimal? ActualEngHrs { get; set; }

        public List<EngViewMetricsVM> EngViewMetricsVMs { get; set; }


    }
}
