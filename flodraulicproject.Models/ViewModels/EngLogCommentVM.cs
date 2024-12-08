using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models.ViewModels
{
    public class EngLogCommentVM
    {
        public EngLogComment EngLogComment { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> EngLogList { get; set; }
        public string? Name { get; set; }

    }
}
