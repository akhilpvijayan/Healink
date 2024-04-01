using AutoMapper;
using Healink.Business.Entities;
using Healink.Business.Services.Dto;
using Healink.Data;
using Healink.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Healink.Business.Services.Services
{
    public class UserService : IUserService
    {
        #region properties
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly DataContext _context;
        #endregion

        #region constructor
        public UserService(IMapper mapper, ILogger<UserService> logger, DataContext context)
        {
            this._mapper = mapper;
            this._logger = logger;
            this._context = context;
        }
        #endregion
        //this.logger.LogInformation('Start');

        #region public functions
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await this._context.Users.ToListAsync();
        }

        public UserDto GetPersonalUser(int userId)
        {
            try
            {
                var user = new UserDto();
                user = GetUserPersonalDetails(userId);
                user.Experience =  GetUserExperience(userId);
                user.Education = GetUserEducation(userId);
                return user;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrganizationDetailDto GetOrganizationPersonalDetails(long userId)
        {
            var userRole = this._context.Users.FirstOrDefault(x => x.UserId == userId).RoleId;
            var isOrganizationalUser = true;
            var sqlQuery = $"Exec spGetUserDetails {userId}, {isOrganizationalUser}";
            return this._context.OrganizationDetailDto.FromSqlRaw(sqlQuery).AsEnumerable().SingleOrDefault();
        }

        public bool CheckDuplicateUserName(string username)
        {
            bool isUsernameExist = false;
            var user = this._context.Users.FirstOrDefault(x => x.Username == username);
            if(user != null)
            {
                isUsernameExist = true;
                return isUsernameExist;
            }
            return isUsernameExist;
        }

        public bool CheckDuplicateEmail(string email)
        {
            bool isEmailExist = false;
            var user = this._context.Users.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                isEmailExist = true;
                return isEmailExist;
            }
            return isEmailExist;
        }

        public async Task<bool> UpdateUser(SignUpUserDetailDto userDetails, long userId)
        {
            try
            {
                var user = await this._context.UserDetails.FirstOrDefaultAsync(x => x.UserId == userId);
                user.FirstName = userDetails.FirstName;
                user.LastName = userDetails.LastName;
                user.Specialization = userDetails.Specialization;
                user.CountryId = userDetails.CountryId;
                user.StateId = userDetails.StateId;
                user.Region= userDetails.Region;
                user.UserBio = userDetails.UserBio;
                user.ModifiedBy = userId;
                user.ModifiedDate = DateTime.Now;

                byte[] profileImage = null;
                byte[] profileCover = null;
                if ((bool)userDetails.isProfilePictureUpdated)
                {
                    using (var msProfileImage = new MemoryStream())
                    {
                        if (userDetails.ProfileImage != null)
                        {
                            await userDetails.ProfileImage.CopyToAsync(msProfileImage);
                            profileImage = msProfileImage.ToArray();
                        }
                    }
                    user.ProfileImage = profileImage;
                }
                if ((bool)userDetails.isProfileCoverUpdated)
                {
                    using (var msProfileCover = new MemoryStream())
                    {
                        if (userDetails.ProfileCover != null)
                        {
                            await userDetails.ProfileCover.CopyToAsync(msProfileCover);
                            profileCover = msProfileCover.ToArray();
                        }
                    }
                    user.ProfileCover = profileCover;
                }

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region private functions

        private UserDto GetUserPersonalDetails(long userId)
        {
            var userRole = this._context.Users.FirstOrDefault(x => x.UserId == userId).RoleId;
            var isOrganizationalUser = false;
            var sqlQuery = $"Exec spGetUserDetails {userId}, {isOrganizationalUser}";
            return this._context.UserDto.FromSqlRaw(sqlQuery).AsEnumerable().SingleOrDefault();
        }

        private List<UserExperienceDto> GetUserExperience(long userId)
        {
            var sqlQuery = $"Exec spGetUserExperienceDetails {userId}";
            return this._context.UserExperienceDto.FromSqlRaw(sqlQuery).ToList();
        }

        private List<UserEducationDto> GetUserEducation(long userId)
        {
            var sqlQuery = $"Exec spGetUserEducationDetails {userId}";
            return this._context.UserEducationDto.FromSqlRaw(sqlQuery).ToList();
        }
        #endregion
    }
}
