using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoGYSD.ViewModels.Missa.Programmes
{
    /// <summary>
    /// Represents a view model for a top-up associated with a programme.
    /// </summary>
    public class TopUpViewModel
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
        [Required(ErrorMessage = "Programme Topup Name is required.")]
        [StringLength(100, ErrorMessage = "Programme Topup Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the amount for the top-up.
        /// </summary>
        [Required(ErrorMessage = "Topup Amount(Loti) is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Topup Amount(Loti) must be greater than 0.")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the top-up is active.
        /// </summary>
        [Required(ErrorMessage = "IsActive is required.")]
        public bool IsActive { get; set; }
    }
}
