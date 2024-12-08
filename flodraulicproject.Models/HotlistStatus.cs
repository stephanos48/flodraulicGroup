using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class HotlistStatus
    {

        [Key]
        public int HotlistStatusId { get; set; }
        public string? StatusName { get; set; }
        public string? Notes { get; set; }

    }
}
