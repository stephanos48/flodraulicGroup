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
    public class TimeTrackerVM
    {

        public TimeTracker TimeTracker { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> FloLocationList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> EngineerList { get; set; }
       // public IEnumerable<Engineer> Engineers { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LaborCodeList { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "From Date")]
        public DateOnly FromDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "To Date")]
        public DateOnly ToDate { get; set; }

        public int EngineerId { get; set; }
        [ForeignKey("EngineerId")]
        [ValidateNever]
        public Engineer Engineer { get; set; }

    }
}
