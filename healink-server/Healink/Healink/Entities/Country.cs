using Healink.Business.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Healink.Entities
{
    public class Country : ICountry
    {
        #region properties
        [Key]
        public long CountryId { get; set; }

        public string CountryName { get; set; }
        #endregion

        [InverseProperty("UserCountry")]
        public virtual ICollection<State> UCountry { get; set; }
    }
}
