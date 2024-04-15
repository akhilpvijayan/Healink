using Healink.Business.Entities;
using Healink.Business.Services;
using Healink.Business.Services.Dto;
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

        [HttpGet("organizations/types")]
        public async Task<IActionResult> GetOrganizationTypes()
        {
            try
            {
                var organizationTypes = _orgService.GetOrganizationTypes();
                if (organizationTypes != null)
                {
                    return Ok(organizationTypes);
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

        [HttpGet("organizations/size")]
        public async Task<IActionResult> GetOrganizationSizes()
        {
            try
            {
                var organizationSizes = _orgService.GetOrganizationSizes();
                if (organizationSizes != null)
                {
                    return Ok(organizationSizes);
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

        [HttpPost("organization")]
        public async Task<IActionResult> SignUpOrganization([FromForm] SignUpOrganizationDto orgDetails)
        {
            try
            {
                if (orgDetails != null)
                {
                    var result = await _orgService.SignUpOrganization(orgDetails);
                    if (result != null)
                    {
                        return Ok(new
                        {
                            Message = "Login Success.",
                            AccessToken = result.Item1.ToString(),
                            RefreshToken = result.Item2.ToString(),
                            UserId = result.Item3
                        });
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
