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
        private readonly IAuthorizationService _authService;
        #endregion

        #region constructor
        public AuthorizationController(DataContext context, IOptions<JwtSettings> options, IAuthorizationService authService)
        {
            this._context = context;
            this._jwtSettings = options.Value;
            this._authService = authService;
        }
        #endregion

        #region public functions
        [HttpPost("login")]
        public async Task<IActionResult> UserLogin(string username, string password)
        {
            var token = _authService.generateToken(username, password);
            if(token != null)
            {
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

        #endregion
    }
}
