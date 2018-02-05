﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class Ping
    {
        public int Id { get; set; }

        [Required]
        public DateTime PingDate { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        //public int ResidentId { get; set; }
        public Resident Resident { get; set; }

        [Required]
        //public int AttractionId { get; set; }
        public Attraction Attraction { get; set; }
    }
}