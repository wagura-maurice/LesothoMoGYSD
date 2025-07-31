using System;

namespace MoGYSD.Business.Views.Missa.Enrolments
{
    public class PaymentDetailView
    {
        public int PaymentDetailId { get; set; }
        public int MobileNumber { get; set; }
        public int EnrolmentId { get; set; }
        public string EnrolmentGUId { get; set; }
        public string EnrolmentPostalAddress { get; set; }
        public int PaymentModeId { get; set; }
        public string PaymentModeName { get; set; }
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public int PayeeId { get; set; }
        public string PayeeFullName { get; set; }
        public string PayeeIDNumber { get; set; }
        public int PayPointId { get; set; }
        public string PayPointName { get; set; }
        public int PayeeTypeId { get; set; }
        public string PayeeTypeCode { get; set; }
        public string PayeeTypeDescription { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
