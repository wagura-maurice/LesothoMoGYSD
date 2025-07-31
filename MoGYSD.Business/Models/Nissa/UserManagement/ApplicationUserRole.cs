using Microsoft.AspNetCore.Identity;
using MoGYSD.Business.Models.Common;

namespace MoGYSD.Business.Models.Nissa.UserManagement
{
    public class ApplicationUserRole : IdentityUserRole<string>, IAuditableEntity
    {
        //public virtual ApplicationUser User { get; set; } = default!;
        public virtual ApplicationRole Role { get; set; } = default!;
        public DateTime CreatedOn { get; set; }
        public string CreatedById { get; set; }
        public ApplicationUser CreatedBy { get; set; } = null;
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedById { get; set; }
        public ApplicationUser ModifiedBy { get; set; } = null;

    }

}
