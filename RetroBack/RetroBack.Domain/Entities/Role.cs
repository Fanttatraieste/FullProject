using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroBack.Domain.Entities
{
    public class Role : IdentityRole
    {
        public Role() => UserRoles = new HashSet<UserRole>();

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
