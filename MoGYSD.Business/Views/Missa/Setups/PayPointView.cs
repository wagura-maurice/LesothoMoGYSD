using System;

namespace MoGYSD.Business.Views.Missa.Setups
{
    public class PayPointView
    {
        public int PayPointId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int CommunityCouncilId { get; set; }
        public string CommunityCouncilName { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
