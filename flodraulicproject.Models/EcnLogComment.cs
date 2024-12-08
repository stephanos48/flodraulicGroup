using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class EcnLogComment
    {

        [Key]
        public int Id { get; set; }
        public string? Comment { get; set; }
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

        public int EcnLogId { get; set; }
        [ForeignKey("EcnLogId")]
        [ValidateNever]
        public EcnLog EcnLog { get; set; }

    }
}
