using Healink.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healink.Controllers
{
    [ApiController]
    public class StateController : ControllerBase
    {
        #region properties
        private readonly IStateService _stateService;
        #endregion

        #region constructor
        public StateController(IStateService stateService)
        {
            this._stateService = stateService;
        }
        #endregion

        #region public functions
        [HttpGet("state/{countryId}")]
        public async Task<IActionResult> GetStateByCountryId(long countryId)
        {
            try
            {
                var states = _stateService.GetStateByCountryId(countryId);
                if (states != null)
                {
                    return Ok(states);
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
