using Healink.Business.Services.Dto;

namespace Healink.Business.Services
{
    public interface IExperienceService
    {
        Task<bool> AddUserExperience(List<UserExperienceDto> userExperience, long userId);
    }
}
