using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoKingdomAPI.Controllers
{
    public class LoadDataController : Controller
    {
		private Manager m = new Manager();

        // GET: LoadData
        public ActionResult Index()
        {
			int numTablesLoaded = m.loadData();
			if (numTablesLoaded > 0)
			{
				ViewBag.msg = "Seed Data Loaded! Number of tables loaded: " + numTablesLoaded;
				return View();
			}
			else
			{
				ViewBag.msg = "Could not load seed data";
				return View();
			}
        }
    }
}