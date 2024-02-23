namespace Healink.Business.Entities
{
    public interface IComment
    {
        #region properties
        long CommentId { get; set; }
        string Content { get; set; }
        DateTime TimeStamp { get; set; }
        long PostId { get; set; }
        long UserId { get; set; }
        #endregion
    }
}
