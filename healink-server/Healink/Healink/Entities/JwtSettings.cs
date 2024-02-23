using Healink.Business.Entities;

namespace Healink.Entities
{
    public class JwtSettings : IJwtSettings
    {
        public string securityKey { get; set; }
    }
}
