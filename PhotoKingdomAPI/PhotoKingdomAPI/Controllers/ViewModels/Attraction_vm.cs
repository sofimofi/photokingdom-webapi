﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class AttractionAdd
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public float Lat { get; set; }

        [Required]
        public float Lng { get; set; }

        [Required]
        public int IsActive { get; set; }

        [Required]
        public int CityId { get; set; }
    }

    public class AttractionBase : AttractionAdd
    {
        public int Id { get; set; }
    }
}