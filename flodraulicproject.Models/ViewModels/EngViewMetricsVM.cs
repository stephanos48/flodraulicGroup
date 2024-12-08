using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flodraulicproject.Models.ViewModels
{
    public class EngViewMetricsVM
    {

        public int Id { get; set; }
        public int EngErrHrs { get; set; }
        public int ECNQty { get; set; }
        public decimal? QuotedEngHrs { get; set; }
        public decimal? ActualEngHrs { get; set; }
        
        
    }
}
