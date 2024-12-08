using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models.ViewModels
{
    public class EcnLogVM1
    {

        public int Id {  get; set; }
        public int EngineeringLogId { get; set; }
        public string JobNumber { get; set; }
        public string StatusName { get; set; }
        public string Reason { get; set; }
        public decimal? CostImpact { get; set; }
        public decimal? ECNAddlEngHrs { get; set; }
        public decimal? ECNAddlShopHrs { get; set; }
        public decimal? PCNAddlEngHrs { get; set; }
        public decimal? PCNAddlShopHrs { get; set; }
        public bool AffectPrice { get; set; }
        public string? Notes { get; set; }


    }
}
