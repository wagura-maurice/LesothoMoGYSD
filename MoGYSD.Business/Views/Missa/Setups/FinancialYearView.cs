using System;

namespace MoGYSD.Business.Views.Missa.Setups
{
    /// <summary>
    /// Represents a view model for displaying financial year configuration details.
    /// </summary>
    public class FinancialYearView
    {
        /// <summary>
        /// Gets or sets the unique identifier for the financial year.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name or label of the financial year.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the starting date of the financial year.
        /// </summary>
        public DateOnly StartDate { get; set; }

        /// <summary>
        /// Gets or sets the ending date of the financial year.
        /// </summary>
        public DateOnly EndDate { get; set; }

        /// <summary>
        /// Gets or sets whether the financial year is currently active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date the record was created.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the name of the user who created the record.
        /// </summary>
        public string CreatedByName { get; set; }

        /// <summary>
        /// Gets or sets the date the record was last modified.
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// Gets or sets the name of the user who last modified the record.
        /// </summary>
        public string? ModifiedByName { get; set; }
    }
}
