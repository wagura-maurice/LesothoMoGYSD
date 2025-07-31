// File: MoGYSD/Business/Views/Missa/EligibilityTests/EligibilityTestDetailsView.cs

using System;

namespace MoGYSD.Business.Views.Missa.EligibilityTests
{
    /// <summary>
    /// Represents the detailed outcome for a single household within an eligibility test.
    /// This class maps directly to the columns of the dbo.EligibilityTestDetailsView SQL view.
    /// </summary>
    public class EligibilityTestDetailsView
    {       
        public int Id { get; set; }
        public int EligibilityTestId { get; set; }
       
        public int HouseholdId { get; set; }
        public string HouseholdCode { get; set; } 
        public string HeadOfHouseholdName { get; set; }
      
        public int EligibilityStatusId { get; set; }
        public string EligibilityStatus { get; set; }
        public string EligibilityStatusCode { get; set; }
    
        public int? EnrolmentDetailId { get; set; }
    
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedById { get; set; }
        public string ModifiedByUserName { get; set; }
    }
}