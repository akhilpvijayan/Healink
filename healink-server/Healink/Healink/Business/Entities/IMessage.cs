namespace Healink.Business.Entities
{
    public interface IMessage
    {
        #region properties
        long MessageId { get; set; }
        byte[] MessageContent { get; set; }
        DateTime Timestamp { get; set; }
        bool IsRead { get; set; }
        long SenderId { get; set; }
        long ReceiverId { get; set; }
        long ChatId { get; set; }
        byte[] MessageAesKey { get; set; }
        #endregion
    }
}
