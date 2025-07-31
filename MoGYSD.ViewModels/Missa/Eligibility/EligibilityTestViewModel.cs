using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.ViewModels.Missa.Eligibility
{
    public class EligibilityTestViewModel
    {
        public int Id { get; set; }
        public int? ProgrammeId { get; set; }
        public int? DistrictId { get; set; }
        public List<int> SelectedDistrictIds { get; set; } = new List<int>();
        public int? CommunityCouncilId { get; set; }
        public int? VillageId { get; set; }
        public string Description { get; set; }
        [NotMapped] 
        [Required, Range(1, int.MaxValue, ErrorMessage = "Quota must be at least 1.")]
        public int Quota { get; set; }
        public int TotalProcessed { get; set; }
        public int TotalSelected { get; set; }
        public int TotalWaitlisted { get; set; }
        public int TotalNotEligible { get; set; }
        public int TotalEligiblePreQuota { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<EligibilityTestDetailsViewModel> Details { get; set; }
    }

    public class EligibilityTestDetailsViewModel
    {
        public int Id { get; set; }
        public int EligibilityTestId { get; set; }
        public int EnrolmentDetailId { get; set; }
        public string EnrolleeName { get; set; }
        public int EligibilityStatusId { get; set; }
        public string EligibilityStatusDescription { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedById { get; set; }
        public string ModifiedByUserName { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}