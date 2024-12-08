using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class HotlistResp
    {

        [Key]
        public int HotlistRespId { get; set; }
        public string? RespName { get; set; }
        public string? Notes { get; set; }

    }
}
