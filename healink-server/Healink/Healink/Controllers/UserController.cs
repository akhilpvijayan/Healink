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
        [Route("users/personal/{userId}")]
        public async Task<IActionResult> GetPersonalUsers(long userId)
        {
            var users = await _userService.GetPersonalUsers(userId);
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound();
        }

        [HttpGet]
        [Authorize]
        [Route("users/organizational/{userId}")]
        public async Task<IActionResult> GetOrganizationalUsers(long userId)
        {
            var users = await _userService.GetOrganizationalUsers(userId);
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound();
        }

        [HttpGet]
        [Authorize]
        [Route("users/personals")]
        public async Task<IActionResult> GetAllPersonalUsers()
        {
            var users = await _userService.GetAllPersonalUsers();
            if (users != null)
            {
                return Ok(users);
            }
            return NotFound();
        }

        [HttpGet]
        [Authorize]
        [Route("users/organizationals")]
        public async Task<IActionResult> GetAllOrganizationalUsers()
        {
            var users = await _userService.GetAllOrganizationalUsers();
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

        [HttpGet]
        [Authorize]
        [Route("connection/status/{userId}/{targetId}")]
        public long GetConnectionStatus(long userId, long targetId)
        {
            try
            {
                return _userService.GetConnectionStatus(userId, targetId);
            }
            catch (Exception ex)
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
