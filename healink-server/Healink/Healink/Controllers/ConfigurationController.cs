using Healink.Business.Services;
using Healink.Business.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healink.Controllers
{
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        #region properties
        private readonly IConfigurationService _configService;
        #endregion

        #region constructor
        public ConfigurationController(IConfigurationService configService) {
            _configService = configService;
        }
        #endregion
        [HttpPost("email")]

        public IActionResult SendEmail(string body)
        {
            this._configService.SendEmail(body);
            return Ok();
        }
    }
}
