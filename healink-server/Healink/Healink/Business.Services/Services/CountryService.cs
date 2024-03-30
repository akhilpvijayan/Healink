using AutoMapper;
using Healink.Data;
using Healink.Entities;

namespace Healink.Business.Services.Services
{
    public class CountryService : ICountryService
    {
        #region properties
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly DataContext _context;
        #endregion

        #region constructor
        public CountryService(IMapper mapper, ILogger<UserService> logger, DataContext context)
        {
            this._mapper = mapper;
            this._logger = logger;
            this._context = context;
        }
        #endregion
        #region public functions
        public List<Country> GetAllCountries()
        {
            return this._context.Countries.ToList();
        }
        #endregion
    }
}
