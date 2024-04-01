using Healink.Business.Entities;

namespace Healink.Entities
{
    public class OrganizationSize : IOrganizationSize
    {
        public long OrganizationSizeId { get; set; }
        public string OrganizationSizeType { get; set; }
    }
}
