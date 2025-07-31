using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoGYSD.Business.Views.Missa.Programmes
{
    public class ArrearsConfigurationView
    {
        public int Id { get; set; }
        public int ProgrammeId { get; set; }
        public string ProgrammeName { get; set; }
        public int MaximumCycles { get; set; }
        public int PenaltyId { get; set; }
        public string PenaltyDescription { get; set; }
        public bool AccruedAfterPenalty { get; set; }
        public bool ArrearsOverYear { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedById { get; set; }
        public string ModifiedByName { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
