using Microsoft.AspNetCore.Mvc;

namespace Healink.Business.Services
{
    public interface IConfigurationService
    {
        #region public functions
        public void SendEmail(string body);
        #endregion
    }
}
