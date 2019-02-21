using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace News_portal.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {      
        public string Token { get; set; }

        public List<NewsApplicationUser> NewsUsers { get; set; }
    }
}
