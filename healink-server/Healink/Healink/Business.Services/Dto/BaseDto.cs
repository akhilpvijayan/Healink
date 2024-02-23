using System.ComponentModel.DataAnnotations;

namespace Healink.Business.Services.Dto
{
    public class BaseDto
    {
        public DateTime CreatedDate { get; set; }

        public long CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public long ModifiedBy { get; set; }
    }
}
