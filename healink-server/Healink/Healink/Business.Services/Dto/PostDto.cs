using Microsoft.EntityFrameworkCore;
using System.Buffers.Text;

namespace Healink.Business.Services.Dto
{
    [Keyless]
    public class PostDto : BaseDto
    {
        #region properties
        public long PostId { get; set; }
        public long UserId { get; set; }
        public string Content { get; set; }
        public byte[]? ContentImage { get; set; } = null;
        public long LikeCount { get; set; }
        public string FullName { get; set; }
        public byte[]? ProfileLogo { get; set; } = null;
        public int CommentCount { get; set; }
        #endregion
    }
}
