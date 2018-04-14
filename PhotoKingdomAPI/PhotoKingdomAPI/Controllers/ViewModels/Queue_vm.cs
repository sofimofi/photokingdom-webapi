using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PhotoKingdomAPI.Controllers
{
    public class QueueAdd
    {
		public QueueAdd()
		{
			QueueDate = DateTime.Now;
		}

        public DateTime QueueDate { get; set; }

        [Required]
        public int AttractionId { get; set; }

        public int PhotoId { get; set; }
    }

    public class QueueAddWithPhoto : QueueBase
    {
        public string PhotoPhotoFilePath { get; set; }

        public double PhotoLat { get; set; }

        public double PhotoLng { get; set; }

        public int PhotoResidentId { get; set; }
    }

    public class QueueBase : QueueAdd
    {
        public int Id { get; set; }
    }

	public class QueueWithDetails : QueueBase
	{
        public string PhotoPhotoFilePath { get; set; }

        public double PhotoLat { get; set; }

        public double PhotoLng { get; set; }

        public int PhotoResidentId { get; set; }

        public string PhotoResidentUserName { get; set; }
    }
}
