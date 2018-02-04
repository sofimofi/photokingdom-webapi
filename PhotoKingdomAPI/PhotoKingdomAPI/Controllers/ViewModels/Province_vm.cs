﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class ProvinceAdd
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }
    }

    public class ProvinceBase : ProvinceAdd
    {
        public int Id { get; set; }
    }
}