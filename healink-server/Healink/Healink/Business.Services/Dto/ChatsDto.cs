using Microsoft.EntityFrameworkCore;

namespace Healink.Business.Services.Dto
{
    [Keyless]
    public class ChatsDto
    {
        #region properties
        public long ChatId { get; set; }
        public string MessageContent { get; set; }
        public long ReceiverId { get; set; }
        public long SenderId { get; set; }
        public bool IsRead { get; set; }
        public DateTime Timestamp { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]? ProfileImage { get; set; } = null;
        #endregion
    }
}
