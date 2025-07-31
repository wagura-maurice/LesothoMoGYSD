using MoGYSD.Business.Models.Nissa.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoGYSD.Business.Models.Missa.ProgrammeConfiguration
{
    public class EligibilityCriteriaPovertyStatus
    {
        public int EligibilityCriteriaId { get; set; }
        public EligibilityCriteria EligibilityCriteria { get; set; }

        public int PovertyStatusId { get; set; }
        public SystemCodeDetail PovertyStatus { get; set; }
    }
}
