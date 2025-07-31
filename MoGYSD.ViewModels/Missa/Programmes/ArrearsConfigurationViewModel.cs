using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoGYSD.ViewModels.Missa.Programmes
{
    public class ArrearsConfigurationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Programme")]
        public int ProgrammeId { get; set; }

        [Display(Name = "Programme Name")]
        public string ProgrammeName { get; set; }

        [Required]
        [Display(Name = "Maximum Cycles")]
        [Range(0, int.MaxValue, ErrorMessage = "Minimum Maximum Cycles must be at least 0.")]
        public int MaximumCycles { get; set; }

        [Required]
        [Display(Name = "Form of Penalty")]
        public int? PenaltyId { get; set; }

        [Display(Name = "Penalty Description")]
        public string PenaltyDescription { get; set; }
        [Required]
        [Display(Name = "Accruals After Penalty")]
        public bool AccruedAfterPenalty { get; set; }
        [Required]

        [Display(Name = "Accruals Over Fiscal Year")]
        public bool ArrearsOverYear { get; set; }

        public string CreatedById { get; set; }

        [Display(Name = "Created By")]
        public string CreatedByName { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        public string ModifiedById { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedByName { get; set; }

        [Display(Name = "Modified On")]
        public DateTime? ModifiedOn { get; set; }      
        public bool IsActive { get; set; }
    }
}
