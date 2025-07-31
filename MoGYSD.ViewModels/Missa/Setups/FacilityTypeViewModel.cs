using System.ComponentModel.DataAnnotations;

namespace MoGYSD.Business.ViewModels.Missa.Setups
{
    public class FacilityTypeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "School Type is required.")]
        [StringLength(100, ErrorMessage = "School Type cannot exceed 100 characters.")]
        public string Name { get; set; }     

        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; }
    }
}
