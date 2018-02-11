using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class ResidentCityOwnAdd
    {
        public ResidentCityOwnAdd()
        {
            StartOfOwn = DateTime.Now;
        }

        [Required]
        public DateTime StartOfOwn { get; set; }

        public DateTime? EndOfOwn { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public int ResidentId { get; set; }

        [Required]
        public int CityId { get; set; }
    }

    public class ResidentCityOwnBase : ResidentCityOwnAdd
    {
        public int Id { get; set; }
    }

	public class ResidentCityOwnWithDetails : ResidentCityOwnBase
	{
		public ResidentBase Resident { get; set; }
		public CityBase City { get; set; }
	}
}