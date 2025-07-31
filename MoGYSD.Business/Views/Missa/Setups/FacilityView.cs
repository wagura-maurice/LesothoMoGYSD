using System;

namespace MoGYSD.Business.Views.Missa.Setups
{
    public class FacilityView
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public string BranchCode { get; set; }
        public string IdentificationNumber { get; set; }
        public string FacilityName { get; set; }
        public int FacilityTypeId { get; set; }
        public string FacilityTypeName { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string HeadName { get; set; }
        public string HeadSurname { get; set; }
        public string HeadEmail { get; set; }
        public string HeadPhoneNumber { get; set; }    
        public string CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedById { get; set; }
        public string ModifiedByName { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string FacilityGradesJson { get; set; }
        public ICollection<GradeView> FacilityGrades { get; set; } = new List<GradeView>();
    }
}