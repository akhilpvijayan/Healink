using Healink.Business.Services;
using Healink.Business.Services.Services;
using Healink.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healink.Controllers
{
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        #region properties
        private readonly IOrganizationService _orgService;
        #endregion

        #region constructor
        public OrganizationController(IOrganizationService orgService)
        {
            _orgService = orgService;
        }
        #endregion

        #region public functions
        [HttpGet("organizations/signup")]
        public async Task<IActionResult> GetOrgainsationsForSignup()
        {
            try
            {
                var organizations = _orgService.GetOrgainsationsForSignup();
                if (organizations != null)
                {
                    return Ok(organizations);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("organizations/education")]
        public async Task<IActionResult> GetEducationalOrganizations()
        {
            try
            {
                var organizations = _orgService.GetEducationalOrganizations();
                if (organizations != null)
                {
                    return Ok(organizations);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
