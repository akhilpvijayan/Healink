using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Healink.Business.Entities
{
    public interface IOrganizationDetail
    {
        #region properties
        long OrganizationDetailId { get; set; }

        long UserId { get; set; }

        string OrganizationName { get; set; }

        string OrganizationWebsite { get; set; }

        long OrganizationSize { get; set; }

        string OrganizationLogo { get; set; }

        string OrganizationBio { get; set; }

        long CountryId { get; set; }

        long StateId { get; set; }

        string Region { get; set; }

        long OrganizationTypeId { get; set; }

        int FollowCount { get; set; }

        string TagLine { get; set; }

        #endregion
    }
}
