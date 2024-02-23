using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Healink.Business.Services.Dto
{
    public class UserDto
    {
        #region properties
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public long UserDetailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
        public string UserBio { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Region { get; set; }
        public string Specialization { get; set; }
        public int ConnectionsCount { get; set; }
        #endregion
    }
}
