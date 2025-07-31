using System;

namespace MoGYSD.Business.Views.Missa.Setups
{
    public class PaymentModeView
    {
        public int PaymentModeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedById { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
