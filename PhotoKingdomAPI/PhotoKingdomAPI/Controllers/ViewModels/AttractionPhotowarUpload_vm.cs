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

    // AttractionPhotowarUpload with details needed for AttractionPhotowar View
    public class AttractionPhotowarUploadForPhotowar : AttractionPhotowarUploadBase
    {
        public AttractionPhotowarUploadForPhotowar()
        {
            residentHasVoted = -1; // null
        }
        public PhotoBase Photo { get; set; }
        public string PhotoResidentUserName { get; set; }
        public string PhotoResidentAvatarImagePath { get; set; }
        public int ResidentVotesCount { get; set; }

        // flag indicating whether signed-in Resident has already voted for this photo
        public int residentHasVoted { get; set; }
    }

    // AttractionPhotowarUpload with details needed for Photo View
    public class AttractionPhotowarUploadForPhotoView : AttractionPhotowarUploadBase
    {
        public AttractionPhotowarBase AttractionPhotowar { get; set; }
        public int ResidentVotesCount { get; set; }

        public string AttractionPhotowarAttractionName { get; set; }
    }
}




