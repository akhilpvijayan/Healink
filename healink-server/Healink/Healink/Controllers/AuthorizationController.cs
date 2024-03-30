using Azure.Identity;
using Healink.Business.Entities;
using Healink.Business.Services;
using Healink.Business.Services.Dto;
using Healink.Data;
using Healink.Entities;
using Microsoft.AspNetCore.Authorization;
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
        private readonly Business.Services.IAuthorizationService _authService;
        #endregion

        #region constructor
        public AuthorizationController(Business.Services.IAuthorizationService authService)
        {
            this._authService = authService;
        }
        #endregion

        #region public functions
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> UserLogin([FromBody] UserCredentialsDto userDetails)
        {
            try
            {
                var user = _authService.GenerateToken(userDetails.UserName, userDetails.Password);
                if (user.Result != null)
                {
                    return Ok(new
                    {
                        Message = "Login Success.",
                        AccessToken = user.Result.Item1.ToString(),
                        RefreshToken = user.Result.Item2.ToString(),
                        UserId = user.Result.Item3
                    }); ;
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("refreshtoken")]
        public async Task<IActionResult> RefreshToken(TokenApiDto tokenApiDto)
        {
            try
            {
                if (tokenApiDto != null)
                {
                    var tokens = await _authService.Refresh(tokenApiDto);
                    if (tokens != null)
                    {
                        return Ok(new TokenApiDto()
                        {
                            AccessToken = tokens.Item1,
                            RefreshToken = tokens.Item2,
                        });
                    };
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromForm] SignUpUserDetailDto userDetails)
        {
            try
            {
                if (userDetails != null)
                {
                    var result = await _authService.SignUp(userDetails);
                    if (result != null)
                    {
                        return Ok(result);
                    };
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion
    }
}
