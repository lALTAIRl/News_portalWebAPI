using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace News_portal.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {

        public List<NewsApplicationUser> NewsApplicationUsers { get; set; }

    }   
}