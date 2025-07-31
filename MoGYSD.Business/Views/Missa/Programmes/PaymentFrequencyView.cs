using System.ComponentModel.DataAnnotations;

namespace MoGYSD.Business.Views.Missa.Programmes
{
    /// <summary>
    /// View model for displaying payment frequency details, matching PaymentFrequencies entity.
    /// </summary>
    public class PaymentFrequencyView
    {
        /// <summary>
        /// Gets or sets the unique identifier for the payment frequency.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the payment frequency.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the frequency.
        /// </summary>
        public int FrequencyId { get; set; }

        /// <summary>
        /// Gets or sets the name of the frequency.
        /// </summary>
        public string FrequencyName { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who created the payment frequency.
        /// </summary>
        public string CreatedById { get; set; }

        /// <summary>
        /// Gets or sets the username of the user who created the payment frequency.
        /// </summary>
        public string CreatedByUserName { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the payment frequency was created.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who last modified the payment frequency.
        /// </summary>
        public string ModifiedById { get; set; }

        /// <summary>
        /// Gets or sets the username of the user who last modified the payment frequency.
        /// </summary>
        public string ModifiedByUserName { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the payment frequency was last modified.
        /// </summary>
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the payment frequency is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}