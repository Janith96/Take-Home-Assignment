using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TakeHomeAPI.Context;
using TakeHomeAPI.Models;

namespace TakeHomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _authContext;
        
        public UserController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;           
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            var user = await _authContext.Users
                .FirstOrDefaultAsync(x => x.UserName == userObj.UserName);
            
            if (user == null)
                return NotFound(new { Message = "User not found!" });

            var password = await _authContext.Users
                .FirstOrDefaultAsync(x => x.UserName == userObj.UserName && x.Password == userObj.Password);

            if (password == null)
                return NotFound(new { Message = "Incorrect password!" });

            user.Token = CreateJwtToken(user);

            return Ok(new 
            { 
                Token = user.Token,
                Message = "Login success!" 
            });
        }


        private string CreateJwtToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("hcP7AQK34P5sZ2EQIEot1fJr8bnyY6rMoWBEuuNl6zqDk9s2H0FIIya2we1A1eeR");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, user.Role),
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }

   
}
