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
        [Required]
        public DateTime QueueDate { get; set; }

        [Required]
        public int AttractionId { get; set; }

        [Required]
        public int PhotoId { get; set; }
    }

    public class QueueBase : QueueAdd
    {
        public int Id { get; set; }
    }

	public class QueueWithDetails : QueueBase
	{
        public string PhotoPhotoFilePath { get; set; }

        public string PhotoResidentId { get; set; }

        public string PhotoResidentUserName { get; set; }
    }
}
