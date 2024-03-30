using Healink.Business.Services;
using Healink.Business.Services.Dto;
using LazyCache;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;

namespace Healink.Controllers
{
    [ApiController]
    public class EducationController : ControllerBase
    {
        #region properties
        private readonly IEducationService _educationService;
        #endregion

        #region constructor
        public EducationController(IEducationService educationService)
        {
            this._educationService = educationService;
        }
        #endregion

        #region public functions
        [HttpPost("user/education/{userId}")]
        public IActionResult AddUserEducation(List<UserEducationDto> userEducationDto, long userId)
        {
            try
            {
                var educationDetails = this._educationService.AddUserEducation(userEducationDto, userId).Result;
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
