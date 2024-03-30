using Healink.Business.Entities;
using Healink.Business.Services.Dto;
using Healink.Data;
using Healink.Entities;

namespace Healink.Business.Services.Services
{
    public class ExperienceService: IExperienceService
    {
        #region properties
        private readonly DataContext _context;
        #endregion

        #region constructor
        public ExperienceService(DataContext context)
        {
            this._context = context;
        }
        #endregion
        #region public functions
        public async Task<bool> AddUserExperience(List<UserExperienceDto> userExperience, long userId)
        {
            try
            {
                foreach (UserExperienceDto experience in userExperience)
                {
                    var experienceEntity = new Experience
                    {
                        Title = experience.Title,
                        Company = experience.Company,
                        Location = experience.Location,
                        StartDate = experience.StartDate,
                        EndDate = experience.EndDate,
                        Description= experience.Description,
                        UserId = userId,
                        CompanyId = experience.CompanyId == 0 ? null : experience.CompanyId,
                        CreatedBy = userId,
                        CreatedDate = DateTime.Now,
                        ModifiedBy = userId,
                        ModifiedDate = DateTime.Now
                    };
                    await _context.Experiences.AddAsync(experienceEntity);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
