using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class LaborCode
    {
        [Key]
        public int LaborCodeId { get; set; }
        public string LaborCodeName { get; set; }
        public string? Notes { get; set; }
    }
}
