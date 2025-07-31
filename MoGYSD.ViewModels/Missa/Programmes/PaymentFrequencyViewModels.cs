using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Missa.Programmes
{
    /// <summary>
    /// View model for Payment Frequencies management.
    /// </summary>
    public class PaymentFrequencyViewModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Frequency is required.")]
        public int FrequencyId { get; set; }

        public string FrequencyName { get; set; }
        public bool? IsActive { get; set; }
    }
}
