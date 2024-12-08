using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models.ViewModels
{
    public class CartVM
    {
        [ValidateNever]
        public IEnumerable<SelectListItem> FloLocationList { get; set; }

        public ShoppingCart ShoppingCart { get; set; }
        public IEnumerable<QohListVM> QohListVM { get; set;}

    }
}
