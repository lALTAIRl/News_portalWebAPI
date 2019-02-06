using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace News_portal.DTO
{
    public class NewsDetailedDTO : NewsDTO
    {
        [Required]
        public string Text { get; set; }
    }
}
