using System;

namespace MoGYSD.Business.Views.Missa.Setups
{
    public class FacilityTypeView
    {
        public int Id { get; set; }

        public string? Name { get; set; }
  
        public bool IsActive { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? CreatedByName { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedByName { get; set; }
    }
}
