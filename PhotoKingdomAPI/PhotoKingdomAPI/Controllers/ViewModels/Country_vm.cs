using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class CountryAdd 
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public int ContinentId { get; set; }
    }
    
    public class CountryBase : CountryAdd
    {
        public int Id { get; set; }
    }

	public class CountryWithDetails : CountryBase
	{
		public CountryWithDetails()
		{
			Owners = new List<ResidentCountryOwnBase>();
		}
		public String ContinentName { get; set; }
		// all the residents that owned this country
		public IEnumerable<ResidentCountryOwnBase> Owners { get; set; }
	}
}