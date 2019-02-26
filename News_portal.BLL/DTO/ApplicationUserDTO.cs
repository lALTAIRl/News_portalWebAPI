using System.ComponentModel.DataAnnotations;

namespace News_portal.BLL.DTO
{
    public class ApplicationUserDTO
    {
        public string Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
