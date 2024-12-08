using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models.ViewModels
{
    public class EcnLogCommentVM1
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }

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
        public string? JobNumber { get; set; }

        public int EcnLogId { get; set; }
        public EcnLog EcnLog { get; set; } = null;
        public EcnLogComment EcnLogComment { get; set; }

    }
}
