namespace Healink.Business.Entities
{
    public interface IConnection
    {
        #region properties
        long ConnectionId { get; set; }
        DateTime RequestedDate { get; set; }
        DateTime AcceptedDate { get; set; }
        long SenderId { get; set; }
        long ReceiverId { get; set; }
        string Status { get; set; }
        #endregion
    }
}
