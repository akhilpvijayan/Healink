using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healink.Business.Entities
{
    public interface IUserDetail
    {
        #region properties
        long UserDetailId { get; set; }

        long UserId { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string ProfileImage { get; set; }

        string UserBio { get; set; }

        long CountryId { get; set; }

        long StateId { get; set; }

        string Region { get; set; }

        string Specialization { get; set; }

        int ConnectionsCount { get; set; }
        #endregion
    }
}
