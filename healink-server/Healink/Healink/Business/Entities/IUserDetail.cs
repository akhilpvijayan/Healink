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

        byte[] ProfileImage { get; set; }

        byte[] ProfileCover { get; set; }

        string UserBio { get; set; }

        string Gender { get; set; }

        long CountryId { get; set; }

        long StateId { get; set; }

        string Region { get; set; }

        string Specialization { get; set; }

        int? ConnectionsCount { get; set; }
        #endregion
    }
}
