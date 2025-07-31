using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoGYSD.Business.Views.Missa.Enrolments
{
    public class EnrolmentsView
    {
        public int EnrolmentId { get; set; }
        public string EnrolmentGUId { get; set; }
        public int EnrolmentScheduleId { get; set; }
        public int EnrolmentEventDetailId { get; set; }
        public int HouseholdId { get; set; }
        public string PostalAddress { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set; }    
      
    }

 
}