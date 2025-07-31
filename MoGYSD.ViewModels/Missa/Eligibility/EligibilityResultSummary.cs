using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoGYSD.ViewModels.Missa.Eligibility
{
    public class EligibilityResultSummary
    {
        public int? TotalProcessed { get; set; }
        public int? TotalEligible { get; set; }
        public int? TotalSelected { get; set; }
        public int? TotalWaitlisted { get; set; }
        public int? TotalNotEligible { get; set; }
    }
}
