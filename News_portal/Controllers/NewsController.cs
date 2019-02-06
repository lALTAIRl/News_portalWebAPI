using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using News_portal.BLL.Interfaces;
using News_portal.DAL.Entities;
using News_portal.DTO;
using AutoMapper;

namespace News_portal.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

      
        // GET: api/News
        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {
            var _mapper = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsDTO>()).CreateMapper();
            var newsCollection = _mapper.Map<IEnumerable<News>, IEnumerable<NewsDTO>>(await _newsService.GetAllNewsAsync());
            return Ok(newsCollection);
        }

        // GET: api/News/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetNews(int id)
        {
            var _mapper = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsDetailedDTO>()).CreateMapper();
            var newsDTO = _mapper.Map<NewsDetailedDTO>( await _newsService.GetNewsByIdAsync(id));
            if(newsDTO == null)
            {
                return NotFound();
            }
            return Ok(newsDTO);
        }

        // POST: api/News
        [HttpPost]
        public async Task<IActionResult> CreateNews([FromBody]NewsDetailedDTO newsDTO)
        {
            if (ModelState.IsValid)
            {
                var _mapper = new MapperConfiguration(cfg => cfg.CreateMap<NewsDetailedDTO, News>()).CreateMapper();
                var news = _mapper.Map<News>(newsDTO);
                news.DateOfCreating = DateTime.Now;
                await _newsService.CreateNewsAsync(news);
                return Ok(news);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/News/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNews(int id, [FromBody] NewsDetailedDTO newsDTO)
        {
            var news = await _newsService.GetNewsByIdAsync(id);
            newsDTO.Id = id;
            if (ModelState.IsValid)
            {
                var _mapper = new MapperConfiguration(cfg => cfg.CreateMap<NewsDetailedDTO, News>()).CreateMapper();
                _mapper.Map(newsDTO, news);
                await _newsService.UpdateNewsAsync(news);
                return Ok(news);
            }
            else return BadRequest(ModelState);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            var news = await _newsService.GetNewsByIdAsync(id);
            if (news==null)
            {
                return NotFound();
            }
            else
            {
                await _newsService.DeleteNewsAsync(news); 
                return NoContent();
            }
        }
    }
}
