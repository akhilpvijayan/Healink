using Healink.Business.Services;
using Healink.Business.Services.Dto;
using Healink.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region properties
        private IUserService _userService;
        #endregion

        #region constructor
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion
        #region public function
        [HttpGet]
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
        [Route("users/{userid}")]
        public async Task<IActionResult> GetUser(int userid)
        {
            try
            {
                var user = _userService.GetUser(userid);
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("isduplicateusername")]
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
        #endregion

    }
}
