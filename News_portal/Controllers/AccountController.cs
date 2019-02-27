using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using News_portal.BLL.DTO;
using News_portal.BLL.Interfaces;
using News_portal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace News_portal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, IMapper mapper, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] InputApplicationUserDTO userDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userService.GetUserByEmailAsync(userDTO.Email);
                //var user = _userManager.Users.SingleOrDefault(r => r.Email == userDTO.Email);
                return Ok(await GenerateJwtToken(userDTO.Email, user));
            }

            return BadRequest("Wrong UserName or Password");
            //throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] InputApplicationUserDTO userDTO)
        {
            var user = _mapper.Map<ApplicationUser>(userDTO);
            user.UserName = user.Email;
            //var user = new ApplicationUser
            //{
            //    UserName = userDTO.Email,
            //    Email = userDTO.Email
            //};
            var result = await _userManager.CreateAsync(user, userDTO.Password);
            //var result = await _userService.CreateUserAsync(user, userDTO.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Ok(await GenerateJwtToken(userDTO.Email, user));
            }
            return BadRequest("Invalid data");
            //throw new ApplicationException("UNKNOWN_ERROR");
        }

        public async Task<IActionResult> Logout()
        {
            return Ok();
        }

        private async Task<IActionResult> GenerateJwtToken(string email, ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}