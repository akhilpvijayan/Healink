using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Healink.Business.Entities
{
    public interface ILikes
    {
        long LikeId { get; set; }

        long PostId { get; set; }

        long UserId { get; set; }
    }
}
