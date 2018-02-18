using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class ContinentAdd
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }

    public class ContinentBase : ContinentAdd
    {
        public int Id { get; set; }
    }

    public class ContinentWithCountries : ContinentBase
    {
        public ContinentWithCountries()
        {
            Countries = new List<CountryBase>();
        }

        // All countries in this continent
        public IEnumerable<CountryBase> Countries { get; set; }
    }

    public class ContinentWithOwners : ContinentBase
	{
		public ContinentWithOwners()
		{
			Owners = new List<ResidentContinentOwnBase>();
		}
		// all the residents that owned this Continent
		public IEnumerable<ResidentContinentOwnBase> Owners { get; set; }
	}
}