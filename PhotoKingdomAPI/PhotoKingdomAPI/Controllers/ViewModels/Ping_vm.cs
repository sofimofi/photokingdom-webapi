﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class PingAdd
    {
        public PingAdd()
        {
            PingDate = DateTime.Now;
            ExpiryDate = DateTime.Now.AddDays(7);
        }

        public DateTime PingDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        [Required]
        public int ResidentId { get; set; }

        [Required]
        public string AttractionName { get; set; }

        [Required]
        public string AttractionGooglePlaceId { get; set; }
    }

    public class PingBase : PingAdd
    {
        public int Id { get; set; }
    }

	public class PingWithDetails : PingBase
	{
		public ResidentBase Resident { get; set; }
		public AttractionBase Attraction { get; set; }
	}
}