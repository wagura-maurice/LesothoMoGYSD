using System.ComponentModel.DataAnnotations;
using MoGYSD.Business.Models;
using Microsoft.AspNetCore.Mvc;
using MoGYSD.Business.Models.Nissa.UserManagement;

namespace MoGYSD.Services.Interfaces

{
    public interface IEntity
    {
        [HiddenInput]
        object Id { get; set; }

        [Required]
        string CreatedById { get; set; }

        [Required]
        DateTime CreatedOn { get; set; }

        [Required]
        ApplicationUser CreatedBy { get; set; }

        string ModifiedById { get; set; }

        DateTime? ModifiedDate { get; set; }

        ApplicationUser ModifiedBy { get; set; }
    }

    public interface IEntity<T> : IEntity
    {
        new T Id { get; set; }
    }
}