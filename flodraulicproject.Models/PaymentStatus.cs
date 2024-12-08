using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class PaymentStatus
    {

        [Key]
        public int PaymentStatusId { get; set; }
        public string PaymentStatusName { get; set; }
        public string? Notes { get; set; }

    }
}
