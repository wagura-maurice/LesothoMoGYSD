using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoGYSD.Business.Models.Missa.Validation
{
    public class ValidatedMember: BaseAuditableEntity<int>
    {

        public int ValidationListId { get; set; }
        [ForeignKey("ValidationListId")]
        public virtual ValidationList ValidationList { get; set; }
  
        public int OriginalHouseholdId { get; set; }
        public int OriginalHouseholdMemberId { get; set; }
        public string OriginalHouseholdGUId { get; set; } 

        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string Surname { get; set; }
        public string NationalId { get; set; }
        public DateTime DOB { get; set; }       
        public int ValidationStatusId { get; set; }
        [ForeignKey("ValidationStatusId")]
        public virtual SystemCodeDetail ValidationStatus { get; set; }      
        public string Notes { get; set; }

        public DateTime? ValidatedOn { get; set; }
        public int? ValidatedById { get; set; } 


    }
}
