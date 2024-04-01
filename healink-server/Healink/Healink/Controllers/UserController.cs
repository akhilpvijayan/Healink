using Healink.Business.Services;
using Healink.Business.Services.Dto;
using Healink.Data;
using Healink.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healink.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        #region properties
        private IUserService _userService;
        private readonly DataContext _context;
        #endregion

        #region constructor
        public UserController(IUserService userService, DataContext context)
        {
            _userService = userService;
            this._context = context;
        }
        #endregion
        #region public function
        [HttpGet]
        [Authorize]
        [Route("users")]
        public async Task<IActionResult> GetAllUsers() 
        {
            var users = _userService.GetAllUsers();
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound();
        }

        [HttpGet]
        [Authorize]
        [Route("users/{userid}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            try
            {
                var userRole = this._context.Users.FirstOrDefault(x => x.UserId == userId).RoleId;
                if (userRole != null && userRole == 3)
                {
                    var user = _userService.GetOrganizationPersonalDetails(userId);
                    if (user != null)
                    {
                        return Ok(user);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else if(userRole != null)
                {
                    var user = _userService.GetPersonalUser(userId);
                    if (user != null)
                    {
                        return Ok(user);
                    }
                    else
                    {
                        return NotFound();
                    }
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

        [HttpPut]
        [Authorize]
        [Route("user/{userid}")]
        public async Task<IActionResult> UpdateUser([FromForm] SignUpUserDetailDto userDetails, long userid)
        {
            try
            {
                var user = _userService.UpdateUser(userDetails, userid);
                if (user.Result != null)
                {
                    return Ok(user.Result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("isduplicateusername/{username}")]
        public bool ChackDuplicateUserName(string username)
        {
            try
            {
                return _userService.CheckDuplicateUserName(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("isemailexist/{email}")]
        public bool ChackDuplicateEmail(string email)
        {
            try
            {
                return _userService.CheckDuplicateEmail(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
