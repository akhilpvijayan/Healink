using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Healink.Business.Entities
{
    public interface IChats
    {
        long ChatId { get; set; }
        long SendUserId { get; set; }
        long ReceivedUserId { get; set; }
    }
}
