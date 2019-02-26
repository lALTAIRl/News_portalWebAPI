using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News_portal.BLL.Interfaces;
using News_portal.BLL.DTO;
using Microsoft.AspNetCore.Authorization;

namespace News_portal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUserDTO>>> GetAllUsers()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<ApplicationUserDTO>> GetUser()
        {
            return Ok();
        }    

        [HttpPost]
        public async Task<IActionResult> CreateUser()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            return Ok();
        }
    }
}