using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoGYSD.Business.Views.Missa.Programmes
{
    public  class OVCBConfigurationView
    {
        public int Id { get; set; }
        public int ProgrammeId { get; set; }
        public string ProgrammeName { get; set; }

        public int FacilityTypeId { get; set; }
        public string FacilityTypeName { get; set; }

        public int GradeId { get; set; }
        public string GradeCode { get; set; }

        public int FeeTypeId { get; set; }
        public string FeeTypeName { get; set; }

        public decimal FeeAmount { get; set; }

        public int FinYearId { get; set; }
        public string FinYearName { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedByName { get; set; }

        public DateTime ModifiedOn { get; set; }
        public string ModifiedByName { get; set; }
    }
}
