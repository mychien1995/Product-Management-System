using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProductMS.DataAccess.SqlServer.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }
}
