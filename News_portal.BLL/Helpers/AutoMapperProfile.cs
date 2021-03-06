﻿using AutoMapper;
using News_portal.BLL.DTO;
using News_portal.DAL.Entities;

namespace News_portal.BLL.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, OutputApplicationUserDTO>();
            CreateMap<InputApplicationUserDTO, ApplicationUser>();

            CreateMap<News, NewsDTO>();
            CreateMap<News, NewsDetailedDTO>();
            CreateMap<NewsDetailedDTO, News>();

        }
    }
}
