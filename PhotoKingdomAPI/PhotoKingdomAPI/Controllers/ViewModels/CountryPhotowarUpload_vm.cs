﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class CountryPhotowarUploadAdd
    {
        public int? IsWinner { get; set; }

        public int? IsLoser { get; set; }

        [Required]
        public int PhotoId { get; set; }

        [Required]
        public int CountryPhotowarId { get; set; }
    }

    public class CountryPhotowarUploadBase : CountryPhotowarUploadAdd
    {
        public int Id { get; set; }
    }

	public class CountryPhotowarUploadWithDetails : CountryPhotowarUploadBase
	{
		public CountryPhotowarUploadWithDetails()
		{
			ResidentVotes = new List<ResidentBase>();
		}
		public PhotoBase Photo { get; set; }
		public CountryPhotowarBase CountryPhotowar { get; set; }
		// Votes for this CountryPhotowarUpload
		public IEnumerable<ResidentBase> ResidentVotes { get; set; }
	}
}