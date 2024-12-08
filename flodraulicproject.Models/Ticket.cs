using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class Ticket
    {

        [Key]
        public int Id { get; set; }

        public string Issue { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        public int TicketStatusId { get; set; }
        [ForeignKey("TicketStatusId")]
        [ValidateNever]
        public TicketStatus TicketStatus { get; set; }

        public string? Notes { get; set; }

    }
}
