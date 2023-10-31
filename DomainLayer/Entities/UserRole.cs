using Microsoft.AspNetCore.Identity;

namespace DomainLayer.Entities
{
    public class UserRole : IdentityUserRole<int>
    {
         public int UserId { get; set; }
         public User User { get; set; }  
         public int RoleId { get; set; }
         public Role Role { get; set; }
    }
}
