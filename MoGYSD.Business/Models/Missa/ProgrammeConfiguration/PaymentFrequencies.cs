using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Nissa.Admin;

namespace MoGYSD.Business.Models.Missa.ProgrammeConfiguration
{
    /// <summary>
    /// Represents a payment frequency option for a programme.
    /// </summary>
    public class PaymentFrequencies : BaseAuditableEntity<int>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the payment frequency.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the display name of the payment frequency.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the foreign key to SystemCodeDetail for the frequency type.
        /// </summary>
        public int FrequencyId { get; set; }
        public virtual SystemCodeDetail Frequency { get; set; }

      
        public bool IsActive { get; set; }
    }
}