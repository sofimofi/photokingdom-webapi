using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class ContinentPhotowarUploadAdd
    {
        public int IsWinner { get; set; }

        public int IsLoser { get; set; }

        [Required]
        public int PhotoId { get; set; }

        [Required]
        public int ContinentPhotowarId { get; set; }
    }

    public class ContinentPhotowarUploadBase : ContinentPhotowarUploadAdd
    {
        public int Id { get; set; }
    }

	public class ContinentPhotowarUploadWithDetails : ContinentPhotowarRequestedphotoUploadBase
	{
		public ContinentPhotowarUploadWithDetails()
		{
			ResidentVotes = new List<ResidentBase>();
		}
		public PhotoBase Photo { get; set; }
		public ContinentPhotowarBase ContinentPhotowar { get; set; }
		// Votes for this ContinentPhotowar
		public IEnumerable<ResidentBase> ResidentVotes { get; set; }
	}
}