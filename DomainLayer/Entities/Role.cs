using Microsoft.AspNetCore.Identity;

namespace DomainLayer.Entities
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRole { get; set; }
    }
}
