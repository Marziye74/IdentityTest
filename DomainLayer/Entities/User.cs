using Microsoft.AspNetCore.Identity;

namespace DomainLayer.Entities
{
    public class User : IdentityUser<int>
    {
        public ICollection<UserRole> UserRole { get; set; }
    }
}
  