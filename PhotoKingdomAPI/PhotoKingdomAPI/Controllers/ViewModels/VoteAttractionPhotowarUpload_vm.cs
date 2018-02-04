using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class VoteAttractionPhotowarUploadAdd
    {
        [Key]
        public int ResidentId { get; set; }

        [Key]
        public int AttractionPhotowarUploadId { get; set; }
    }

    public class VoteAttractionPhotowarUploadBase : VoteAttractionPhotowarUploadAdd
    {

    }
}