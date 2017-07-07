using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CsharpMVCTest.Models;

namespace CsharpMVCTest.Controllers
{
    public class NewHomeController : Controller
    {
        //
        // GET: /NewHome/
        public ActionResult Index()
        {
            newHomeViewModel aa = new newHomeViewModel();
            aa.FirstPart = newHome.aa();
            aa.SecondPart = newHome.bb();
            return View(aa);
        }
	}
}