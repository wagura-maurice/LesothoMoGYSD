
using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Missa.Setups;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.UserManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoGYSD.Business.Models.Missa.ProgrammeConfiguration
{
    /// <summary>
    /// Represents configuration for OVC-B programme fees by facility type, grade, and fee type.
    /// </summary>
    public class OVCBConfiguration:BaseAuditableEntity<int>
    {

     
        public int ProgrammeId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the facility type (e.g. day, boarding).
        /// </summary>    
        public int FacilityTypeId { get; set; }

        /// <summary>
        /// Gets or sets the grade ID applicable to this configuration.
        /// </summary>  
        public int GradeId { get; set; }

        /// <summary>
        /// Gets or sets the fee type ID (e.g. tuition, stationery).
        /// </summary>  
        public int FeeTypeId { get; set; }

        /// <summary>
        /// Gets or sets the fee amount applicable for the configuration.
        /// </summary>

        [Column(TypeName = "decimal(18,2)")]
        public decimal FeeAmount { get; set; }

        /// <summary>
        /// Gets or sets the financial year ID for which the configuration applies.
        /// </summary>

        [ForeignKey("FinancialYear")]
        public int FinYearId { get; set; }

        /// <summary>
        /// Gets or sets the status of the configuration.
        /// True means active; false means inactive.
        /// </summary>

        public bool Status { get; set; }

        /// <summary>
        /// Navigation property for the user who created the bank record.
        /// </summary>
        public virtual ApplicationUser CreatedBy { get; set; }
        /// <summary>
        /// Navigation property for the user who last modified the bank record.
        /// </summary>
        public virtual ApplicationUser ModifiedBy { get; set; }

        // Navigation properties

        /// <summary>
        /// Navigation property for the associated programme.
        /// </summary>
        public virtual Programmes Programme { get; set; }

        /// <summary>
        /// Navigation property for the associated facility type.
        /// </summary>
        public virtual FacilityType FacilityType { get; set; }

        /// <summary>
        /// Navigation property for the associated grade.
        /// </summary>
        public virtual Grade Grade { get; set; }

        /// <summary>
        /// Navigation property for the associated fee type from system codes.
        /// </summary>ss
        public virtual SystemCodeDetail FeeType { get; set; }

        /// <summary>
        /// Navigation property for the financial year.
        /// </summary>
        public virtual FinancialYear FinancialYear { get; set; }

    }
}
