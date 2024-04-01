using Healink.Business.Services.Dto;
using Healink.Entities;

namespace Healink.Business.Services
{
    public interface IOrganizationService
    {
        #region properties
        IEnumerable<object> GetOrgainsationsForSignup();
        IEnumerable<object> GetEducationalOrganizations();
        IEnumerable<object> GetOrganizationTypes();
        IEnumerable<object> GetOrganizationSizes();
        Task<Tuple<string, string, long>> SignUpOrganization(SignUpOrganizationDto orgDetails);
        #endregion
    }
}
