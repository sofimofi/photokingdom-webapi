using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class AttractionPhotowarUploadAdd
    {
        public int? IsWinner { get; set; }

        public int? IsLoser { get; set; }

        [Required]
        public int PhotoId { get; set; }

        [Required]
        public int AttractionPhotowarId { get; set; }
    }

    public class AttractionPhotowarUploadBase : AttractionPhotowarUploadAdd
    {
        public int Id { get; set; }
    }

	public class AttractionPhotowarUploadWithDetails : AttractionPhotowarUploadBase
	{
		public AttractionPhotowarUploadWithDetails()
		{
			ResidentVotes = new List<ResidentBase>();
		}
		public PhotoBase Photo { get; set; }
		public AttractionPhotowarBase AttractionPhotoWar { get; set; }
		// all the votes for this Photo
		public IEnumerable<ResidentBase> ResidentVotes { get; set; }
	}

    public class AttractionPhotowarUploadForPhotowar : AttractionPhotowarUploadBase
    {
        public PhotoBase Photo { get; set; }
        public string PhotoResidentUserName { get; set; }
        public string PhotoResidentAvatarImagePath { get; set; }
        public int ResidentVotesCount { get; set; }
    }
}