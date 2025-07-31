using System;
using System.Collections.Generic; // Required for List<T>

namespace MoGYSD.Business.Views.Missa.Programmes
{
    /// <summary>
    /// View for ValidationList entity, representing a community validation exercise header
    /// and its associated detail lines.
    /// </summary>
    public class ValidationListView
    {       
        public int Id { get; set; }
        public int TotalVillages { get; set; }
        public int TotalHouseholds { get; set; }
        public int TotalMembers { get; set; }
        public int ValidatedMembers { get; set; }
        public int PendingValidation { get; set; }            
        public int? CommunityCouncilId { get; set; }
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string CommunityCouncilName { get; set; }
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedOn { get; set; }

        // --- Collection of detail items ---
        public List<ValidationDetailView> ValidationDetails { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationListView"/> class.
        /// </summary>
        public ValidationListView()
        {
            // Initialize the list to prevent null reference errors.
            ValidationDetails = new List<ValidationDetailView>();
        }


        /// <summary>
        /// Represents a single detail line in a validation exercise.
        /// </summary>
        public class ValidationDetailView
        {
            public int Id { get; set; }
            public int ValidationListId { get; set; }
            public int HouseholdMemberId { get; set; }
            public string HouseholdMemberName { get; set; }
            public int ValidationStatusId { get; set; }
            public string ValidationStatusName { get; set; }
        }
    }
}