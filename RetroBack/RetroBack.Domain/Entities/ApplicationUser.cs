using Microsoft.AspNetCore.Identity;


namespace RetroBack.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public bool IsDisabledByAdmin { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
