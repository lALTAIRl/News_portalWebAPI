﻿using System;
using System.Collections.Generic;

namespace News_portal.DAL.Entities
{
    public class News
    {
        public int Id { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public string Text { get; set; } 

        public string ImageURL { get; set; }

        public DateTime DateOfCreating { get; set; }

        public bool IsPublished { get; set; }

        public DateTime DateOfPublishing { get; set; }

        public List<NewsApplicationUser> NewsApplicationUsers { get; set; }

    }
}
