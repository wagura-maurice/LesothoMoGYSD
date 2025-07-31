using System;

namespace MoGYSD.Business.Views.Missa.Enrolments
{
    public class EnrolmentDetailsView
    {
        public int EnrolmentDetailId { get; set; }
        public int HouseholdMemberId { get; set; }
        public int GradeId { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}