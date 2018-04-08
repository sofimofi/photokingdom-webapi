using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class ResidentProvinceOwnAdd
    {
        public ResidentProvinceOwnAdd()
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
        public int ProvinceId { get; set; }
    }

    public class ResidentProvinceOwnBase : ResidentProvinceOwnAdd
    {
        public int Id { get; set; }
    }

	public class ResidentProvinceOwnWithDetails : ResidentProvinceOwnBase
	{
		public ResidentBase Resident { get; set; }
		public ProvinceBase Province { get; set; }
	}

    public class ResidentProvinceOwnForMapView : ResidentProvinceOwnBase
    {
        public String ResidentUserName { get; set; }
        public String ResidentAvatarImagePath { get; set; }
    }
}