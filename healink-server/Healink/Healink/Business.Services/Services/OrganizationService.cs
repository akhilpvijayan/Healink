using Healink.Business.Entities;
using Healink.Business.Services.Dto;
using Healink.Data;
using Healink.Entities;
using Healink.Helper;

namespace Healink.Business.Services.Services
{
    public class OrganizationService : IOrganizationService
    {
        #region properties
        private readonly IConfigurationService _configService;
        private readonly DataContext _context;
        private readonly IAuthorizationService _authService;
        private long educationalOrganization = 19;
        #endregion

        #region constructor
        public OrganizationService(IConfigurationService configService, DataContext context, IAuthorizationService authService)
        {
            _configService = configService;
            _context = context;
            _authService = authService;
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

        public IEnumerable<object> GetOrganizationTypes()
        {
            return this._context.IndustryTypes.ToList();
        }

        public IEnumerable<object> GetOrganizationSizes()
        {
            return this._context.OrganizationSize.ToList();
        }

        public async Task<Tuple<string, string, long>> SignUpOrganization(SignUpOrganizationDto orgDetails)
        {
            try
            {
                User user = new User();
                user.Username = orgDetails.Username;
                user.Password = PasswordHasher.HashPassword(orgDetails.Password);
                user.Email = orgDetails.Email;
                user.RoleId = orgDetails.RoleId;
                user.LastLogin = DateTime.Now;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                byte[] profileImage = null;
                byte[] profileCover = null;
                using (var ms = new MemoryStream())
                {
                    if (orgDetails.OrganizationLogo != null)
                    {
                        await orgDetails.OrganizationLogo.CopyToAsync(ms);
                        profileImage = ms.ToArray();
                    }

                    if (orgDetails.OrganizationCover != null)
                    {
                        await orgDetails.OrganizationCover.CopyToAsync(ms);
                        profileCover = ms.ToArray();
                    }
                }

                OrganizationDetail orgDetail = new OrganizationDetail();
                orgDetail.UserId = user.UserId;
                orgDetail.OrganizationLogo = profileImage;
                orgDetail.OrganizationCover = profileCover;
                orgDetail.CountryId = orgDetails.CountryId;
                orgDetail.StateId = orgDetails.StateId;
                orgDetail.Region = orgDetails.Region;
                orgDetail.TagLine = orgDetails.Tagline;
                orgDetail.OrganizationWebsite = orgDetails.OrganizationWebsite;
                orgDetail.OrganizationSize = orgDetails.OrganizationSize;
                orgDetail.OrganizationBio = orgDetails.OrganizationBio;
                orgDetail.OrganizationTypeId = orgDetails.OrganizationType;
                orgDetail.OrganizationName = orgDetails.OrganizationName;
                orgDetail.CreatedDate = DateTime.Now;
                orgDetail.CreatedBy = 0;
                orgDetail.ModifiedDate = DateTime.Now;
                orgDetail.ModifiedBy = 0;

                _context.OrganizationDetails.Add(orgDetail);
                await _context.SaveChangesAsync();


                return await this._authService.GenerateToken(orgDetails.Username, orgDetails.Password);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
