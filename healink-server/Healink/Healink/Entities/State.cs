using Healink.Business.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healink.Entities
{
    public class State: IState
    {
        #region properties
        [Key]
        public long StateId { get; set; }
        public string StateName { get; set; }
        [ForeignKey("Country")]
        public long CountryId { get; set; }
        #endregion
        [InverseProperty("UCountry")]
        public virtual Country UserCountry { get; set; }

        [InverseProperty("UserState")]
        public virtual ICollection<UserDetail> UState { get; set; }
    }
}
