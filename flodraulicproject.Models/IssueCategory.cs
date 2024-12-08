using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class IssueCategory
    {

        [Key]
        public int IssueCategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Notes { get; set; }

    }
}
