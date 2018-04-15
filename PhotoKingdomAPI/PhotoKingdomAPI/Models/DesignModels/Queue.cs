using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Models
{
    public class Queue
    {
		public Queue()
		{
			QueueDate = DateTime.Now;
		}

        public int Id { get; set; }

        [Required]
        public DateTime QueueDate { get; set; }

        [Required]
        public int AttractionId { get; set; }

        [Required]
        public int PhotoId { get; set; }
        
        // navigations

        public Attraction Attraction { get; set; }

        public Photo Photo { get; set; }
    }
}