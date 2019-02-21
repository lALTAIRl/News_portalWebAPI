using System.ComponentModel.DataAnnotations;

namespace News_portal.BLL.DTO
{
    public class NewsDetailedDTO : NewsDTO
    {
        [Required]
        public string Text { get; set; }
    }
}
