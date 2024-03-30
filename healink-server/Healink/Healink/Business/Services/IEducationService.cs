using Healink.Business.Services.Dto;

namespace Healink.Business.Services
{
    public interface IEducationService
    {
        Task<bool> AddUserEducation(List<UserEducationDto> userEducation, long userId);
    }
}
