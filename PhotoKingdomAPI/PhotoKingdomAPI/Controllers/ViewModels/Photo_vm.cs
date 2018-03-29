using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class PhotoAdd
    {
        [Required]
        [StringLength(100)]
        public string PhotoFilePath { get; set; }

        [Required]
        public double Lat { get; set; }

        [Required]
        public double Lng { get; set; }

        [Required]
        public int ResidentId { get; set; }
    }

    public class PhotoBase : PhotoAdd
    {
        public int Id { get; set; }
    }

	public class PhotoWithDetails : PhotoBase
	{
		public PhotoWithDetails()
		{
			AttractionPhotowarUploads = new List<AttractionPhotowarUploadForPhotoView>();
			CountryPhotowarUploads = new List<CountryPhotowarUploadBase>();
			ContinentPhotowarUploads = new List<ContinentPhotowarUploadBase>();
			CountryPhotowarRequestedphotoUploads = new List<CountryPhotowarRequestedphotoUploadBase>();
			ContinentPhotowarRequestedphotoUploads = new List<ContinentPhotowarRequestedphotoUploadBase>();
		}

        public String ResidentUserName { get; set; }
        public String ResidentAvatarImagePath { get; set; }

		// the Photowars this photo has participated in
		public IEnumerable<AttractionPhotowarUploadForPhotoView> AttractionPhotowarUploads { get; set; }
		public IEnumerable<CountryPhotowarUploadBase> CountryPhotowarUploads { get; set; }
		public IEnumerable<ContinentPhotowarUploadBase> ContinentPhotowarUploads { get; set; }

		// the PhotowarPhotorequests by leaders that this photo has uploaded for
		public IEnumerable<CountryPhotowarRequestedphotoUploadBase> CountryPhotowarRequestedphotoUploads { get; set; }
		public IEnumerable<ContinentPhotowarRequestedphotoUploadBase> ContinentPhotowarRequestedphotoUploads { get; set; }
	}
}