using Healink.Data;

namespace Healink.Business.Services.Services
{
    public class OrganizationService : IOrganizationService
    {
        #region properties
        private readonly IConfigurationService _configService;
        private readonly DataContext _context;
        private long educationalOrganization = 19;
        #endregion

        #region constructor
        public OrganizationService(IConfigurationService configService, DataContext context)
        {
            _configService = configService;
            _context = context;
        }
        #endregion

        #region public function
        public IEnumerable<object> GetOrgainsationsForSignup()
        {
            return this._context.OrganizationDetails.ToList();
        }

        public IEnumerable<object> GetEducationalOrganizations()
        {
            return this._context.OrganizationDetails.Where(o=> o.OrganizationTypeId == this.educationalOrganization).ToList();
        }
        #endregion
    }
}
