namespace Healink.Business.Services.Dto
{
    public class UserDto : UserDetailsDto
    {
        public List<UserExperienceDto>? Experience { get; set; } = null;
        public List<UserEducationDto>? Education { get; set;} = null;
    }
}
