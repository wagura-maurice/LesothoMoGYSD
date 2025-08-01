﻿using System.ComponentModel.DataAnnotations;

namespace MoGYSD.Web.Components.Security.Users;
public class SearchFilter
{
    public string? Name { get; set; }
    public int? District { get; set; }
    public int? CommunityCouncil { get; set; }
    public int? Village { get; set; }
    public string? Role { get; set; }
    public string? SourceOfRegistration { get; set; }
    public int? Status { get; set; }
    public bool? IsActive { get; set; }
}

public class ResetPasswordInputModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }


}
