using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class Engineer
    {

        [Key]
        public int Id { get; set; }
        public string? EngineerName { get; set; }
        public string? Notes { get; set; }
        public string? ImageUrl { get; set; }

    }
}
