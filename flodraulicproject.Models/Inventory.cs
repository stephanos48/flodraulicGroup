using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class Inventory
    {

        [Key]
        public int Id { get; set; }
        public string PartNumber { get; set; }
        public int StartQoh { get; set; }

    }
}
