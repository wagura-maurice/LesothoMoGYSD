using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Nissa.Administration;

public class SystemCodeDetailViewModel
{
    /// <summary>
    /// Gets or sets the unique identifier for the system code detail.
    /// </summary>

    [Display(Name = "ID")]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the foreign key reference to the parent SystemCode.
    /// </summary>
    [Required(ErrorMessage = "System Code ID is required.")]
    [Display(Name = "System Code ID")]
    public int? SystemCodeId { get; set; }

    /// <summary>
    /// Gets or sets the code value for this detail item.
    /// </summary>
    [Required(ErrorMessage = "Code is required.")]
    [StringLength(50, ErrorMessage = "Code cannot exceed 50 characters.")]
    [Display(Name = "Code")]
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the order number for sorting purposes.
    /// </summary>
    [Required(ErrorMessage = "Order number is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Order number must be a positive number.")]
    [Display(Name = "Order Number")]
    public int OrderNo { get; set; }

    /// <summary>
    /// Gets or sets the description of the code detail.
    /// </summary>
    [Required(ErrorMessage = "Description is required.")]
    [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
    [Display(Name = "Description")]
    public string Description { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }
}