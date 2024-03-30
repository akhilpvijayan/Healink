namespace Healink.Business.Entities
{
    public interface IPost
    {
        #region properties
        long PostId { get; set; }
        string Content { get; set; }
        byte[] ContentImage { get; set; }
        long LikeCount { get; set; }
        long UserId { get; set; }
        #endregion
    }
}
