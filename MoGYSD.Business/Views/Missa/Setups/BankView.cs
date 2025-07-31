using System;

namespace MoGYSD.Business.Views.Missa.Setups
{
    public class BankView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? BankDescription { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? CreatedByName { get; set; }

        public string? ModifiedByName { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
