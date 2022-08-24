using FirstStudy.Data;
using FirstStudy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FirstStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly DatabaseContext _context;

        public SignInController(IConfiguration configuration,DatabaseContext databaseContext)
        {
            _configuration = configuration;
            _context = databaseContext;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserInfo _userInfo)
        {
            if (_userInfo != null && _userInfo.UserName != null && _userInfo.UserPass != null)
            {
                var user = await GetUser(_userInfo.UserName, _userInfo.UserPass);

                if (user != null)
                {
                    var tokenstring = GenerateJwtToken(_userInfo.UserName);
                    return Ok(new { Token = tokenstring, Message = "Success" });
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
        private string GenerateJwtToken(string UserName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);
            var tokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", UserName) }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDecriptor);
            return tokenHandler.WriteToken(token);
        }
        private async Task<UserInfo> GetUser(string username, string userpass)
        {
            return await _context.UserInfo.FirstOrDefaultAsync(u => u.UserName == username && u.UserPass == userpass);
        }
    }
}
