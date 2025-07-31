using MoGYSD.Business.Models.Nissa.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoGYSD.Business.Models.Missa.ProgrammeConfiguration
{
    public class EligibilityCriteriaCBC
    {
        public int EligibilityCriteriaId { get; set; }
        public EligibilityCriteria EligibilityCriteria { get; set; }

        public int CBCId { get; set; }
        public SystemCodeDetail CBC { get; set; }
    }
}
