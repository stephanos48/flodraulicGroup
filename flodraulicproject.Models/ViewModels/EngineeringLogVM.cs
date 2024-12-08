using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models.ViewModels
{
    public class EngineeringLogVM
    {

        public EngineeringLog EngineeringLog { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> EngineerList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> EstimatorList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LogStatusList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> MfgLocationList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> SalesLocationList { get; set; }

    }
}
