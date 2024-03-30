using Healink.Business.Services;
using Healink.Caching;
using Healink.Entities;
using LazyCache;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Healink.Controllers
{
    [ApiController]
    public class CountryController : ControllerBase
    {
        #region properties
        private readonly ICountryService _countryService;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region constructor
        public CountryController(ICountryService countryService, ICacheProvider cacheProvider)
        {
            this._countryService = countryService;
            this._cacheProvider = cacheProvider;
        }
        #endregion

        #region public functions
        [HttpGet("country")]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                if (!_cacheProvider.TryGetValue(CacheKeys.Country, out List<Country> countries))
                {
                    countries = _countryService.GetAllCountries();

                    var cacheEntryOption = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(2),
                        SlidingExpiration = TimeSpan.FromMinutes(2),
                        Size = 1024
                    };

                    _cacheProvider.Set(CacheKeys.Country, countries, cacheEntryOption);
                }
                if (countries != null)
                {
                    return Ok(countries);
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
