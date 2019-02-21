using System.ComponentModel.DataAnnotations;

namespace News_portal.BLL.DTO
{
    public class NewsDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Caption { get; set; }

        [Required]
        [StringLength(350, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        public string ImageURL { get; set; }
    }
}
