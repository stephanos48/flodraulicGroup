﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models
{
    public class EcnLogStatus
    {

        [Key]
        public int EcnLogStatusId { get; set; }
        public string? StatusName { get; set; }
        public string? Notes { get; set; }

    }
}
