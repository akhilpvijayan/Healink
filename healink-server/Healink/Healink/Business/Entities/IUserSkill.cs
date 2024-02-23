namespace Healink.Business.Entities
{
    public interface IUserSkill
    {
        #region properties
        long UserSkillId { get; set; }
        long Userid { get; set; }
        long SkillId { get; set; }
        #endregion
    }
}
