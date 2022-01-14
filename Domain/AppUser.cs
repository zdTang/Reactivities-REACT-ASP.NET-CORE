using Microsoft.AspNetCore.Identity;

namespace Domain
{
    /*=========================================
    Be aware: IdentityUser is not a interface !
    Here we can see the power of heritage
    
    ===========================================*/
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }
    }
}