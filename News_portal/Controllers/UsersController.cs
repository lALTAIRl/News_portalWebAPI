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
    [Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<ApplicationUserDTO>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpGet]
        public async Task<ActionResult<ApplicationUserDTO>> GetUser(string id)
        {
            return Ok(await _userService.GetUserByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(ApplicationUserDTO userDTO)
        {
            await _userService.CreateUserAsync(_mapper.Map<ApplicationUser>(userDTO), userDTO.Password);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(ApplicationUserDTO userDTO)
        {
            var user = _userService.GetUserByIdAsync(userDTO.Id);
            await _userService.UpdateUserAsync(_mapper.Map<ApplicationUser>(userDTO));
            return Ok(_mapper.Map(user, userDTO));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}