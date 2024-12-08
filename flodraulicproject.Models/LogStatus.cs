using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class LogStatus
    {

        [Key]
        public int LogStatusId { get; set; }
        public string? LogStatusName { get; set; }
        public string? Notes { get; set; }

    }
}
