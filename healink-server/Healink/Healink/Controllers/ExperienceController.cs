using Healink.Business.Services.Dto;
using Healink.Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healink.Controllers
{
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        #region properties
        private readonly IExperienceService _experienceService;
        #endregion

        #region constructor
        public ExperienceController(IExperienceService experienceService)
        {
            this._experienceService = experienceService;
        }
        #endregion

        #region public functions
        [HttpPost("user/experience/{userId}")]
        public IActionResult AddUserExperience(List<UserExperienceDto> userExperience, long userId)
        {
            try
            {
                var educationDetails = this._experienceService.AddUserExperience(userExperience, userId).Result;
                if (educationDetails)
                {
                    return Ok(educationDetails);
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
