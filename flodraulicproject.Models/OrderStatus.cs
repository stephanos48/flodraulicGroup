using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class OrderStatus
    {

        [Key]
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public string? Notes { get; set; }

    }
}
