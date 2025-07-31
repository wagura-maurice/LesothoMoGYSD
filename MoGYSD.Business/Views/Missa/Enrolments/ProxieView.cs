using System;

namespace MoGYSD.Business.Views.Missa.Enrolments
{
    public class ProxieView
    {
        public int ProxieId { get; set; }
        public string GUId { get; set; }
        public string IDNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string PhoneNumber { get; set; }
        public int PaymentDetailsId { get; set; }
        public int GenderId { get; set; }
        public string GenderDescription { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
