using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Missa.Programmes
{
    /// <summary>
    /// Represents a view model for a top-up associated with a programme.
    /// </summary>
    public class TopUpView
    {
        /// <summary>
        /// Gets or sets the unique identifier for the top-up.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the associated programme.
        /// </summary>
        public int ProgrammeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the associated programme.
        /// </summary>
        public string ProgrammeName { get; set; }

        /// <summary>
        /// Gets or sets the name of the top-up.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the amount for the top-up.
        /// </summary>
        public decimal Amount { get; set; }
    
        /// <summary>
        /// Gets or sets a value indicating whether the top-up is active.
        /// </summary>
        public bool IsActive
        {
            get; set;
        }
    }
}