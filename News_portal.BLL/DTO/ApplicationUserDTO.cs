using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace News_portal.BLL.DTO
{
    public class ApplicationUserDTO
    {
        //public string Id { get; set; }

        //public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
