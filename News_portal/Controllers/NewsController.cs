using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using News_portal.BLL.Interfaces;
using News_portal.DAL.Entities;
using News_portal.BLL.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace News_portal.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    //[ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        private readonly IMapper _mapper;
        public NewsController(INewsService newsService, IMapper mapper)
        {
            _newsService = newsService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDTO>>> GetAllNews()
        {
            var newsCollection = _mapper.Map<IEnumerable<News>, IEnumerable<NewsDTO>>(await _newsService.GetAllNewsAsync());
            return Ok(newsCollection);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<NewsDetailedDTO>> GetNews(int id)
        {
            var newsDTO = _mapper.Map<NewsDetailedDTO>( await _newsService.GetNewsByIdAsync(id));
            if(newsDTO == null)
            {
                return NotFound();
            }
            return Ok(newsDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews([FromBody]NewsDetailedDTO newsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var news = _mapper.Map<News>(newsDTO);
            news.DateOfCreating = DateTime.Now;
            await _newsService.CreateNewsAsync(news);
            return Ok(_mapper.Map<NewsDetailedDTO>(news));

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNews(int id, [FromBody] NewsDetailedDTO newsDTO)
        {
            var news = await _newsService.GetNewsByIdAsync(id);
            if(news == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);        
            }
            _mapper.Map(newsDTO, news);
            await _newsService.UpdateNewsAsync(news);
            return Ok(_mapper.Map<NewsDetailedDTO>(news));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            var news = await _newsService.GetNewsByIdAsync(id);
            if (news==null)
            {
                return NotFound();
            }
            await _newsService.DeleteNewsAsync(news); 
            return NoContent();
        }
    }
}
