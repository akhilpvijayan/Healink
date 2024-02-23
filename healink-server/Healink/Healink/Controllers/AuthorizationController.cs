using Azure.Identity;
using Healink.Business.Entities;
using Healink.Business.Services;
using Healink.Data;
using Healink.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Healink.Controllers
{
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        #region properties
        private readonly DataContext _context;
        private readonly JwtSettings _jwtSettings;
        #endregion

        #region constructor
        public AuthorizationController(DataContext context, IOptions<JwtSettings> options)
        {
            this._context = context;
            this._jwtSettings = options.Value;
        }
        #endregion

        #region public functions
        [HttpPost("generatetoken")]
        public async Task<IActionResult> GenerateToken(string username, string password )
        {
            var user = await this._context.Users.FirstOrDefaultAsync(user => user.Username == username && Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(user.Password))) == password);
            if(user != null)
            {
                //generate token
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(this._jwtSettings.securityKey);
                var tokenDesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Email, user.Email)
                    }),
                    Expires = DateTime.UtcNow.AddSeconds(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
                };
                var token = tokenHandler.CreateToken(tokenDesc);
                var finalToken = tokenHandler.WriteToken(token);
                return Ok(finalToken); 
            }
            else
            {
                return Unauthorized();
            }
        }

        #endregion
    }
}
