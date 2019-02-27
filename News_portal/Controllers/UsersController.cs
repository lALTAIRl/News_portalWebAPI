using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News_portal.BLL.DTO;
using News_portal.BLL.Interfaces;
using News_portal.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace News_portal.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutputApplicationUserDTO>>> GetAllUsers()
        {
            return Ok(_mapper.Map<IEnumerable<OutputApplicationUserDTO>>(await _userService.GetAllUsersAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OutputApplicationUserDTO>> GetUser(string id)
        {
            if (await _userService.GetUserByIdAsync(id) == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OutputApplicationUserDTO>(await _userService.GetUserByIdAsync(id)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(InputApplicationUserDTO userDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = _userService.GetUserByEmailAsync(userDTO.Email);
            await _userService.UpdateUserAsync(_mapper.Map<ApplicationUser>(userDTO));
            return Ok(_mapper.Map<OutputApplicationUserDTO>(user));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if(await _userService.GetUserByIdAsync(id) == null)
            {
                return NotFound();
            }
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}