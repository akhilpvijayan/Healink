namespace Healink.Business.Entities
{
    public interface IUser
    {
        #region properties
        long UserId { get; set; }
        string Username { get; set; }
        string Email { get; set; }  
        string Password { get; set; }
        DateTime LastLogin { get; set; }
        DateTime CreatedDate { get; set; }
        bool IsActive { get; set; }
        bool IsVerified { get; set; }
        long RoleId { get; set; }

        #endregion
    }
}
