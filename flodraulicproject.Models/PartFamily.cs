using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class PartFamily
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("PartFamily")]
        public string FamilyName { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }

    }
}
