using CsharpMVCTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsharpMVCTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult gg()
        {
            ViewBag.Title = "Home Page";
            IEnumerable<ggc> gg = new List<ggc> { new ggc() { xString = "gaa", xInt = 1 }, new ggc() { xString = "gbb", xInt = 2 } };
            return View(gg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult gg([Bind(Include = "xInt,xString")]ggc data)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<ggc> gg = new List<ggc> { new ggc() { xString = "gaa", xInt = 1 }, new ggc() { xString = "gbb", xInt = 2 }, data };
                ViewBag.Title = "Home Page";
                return View(gg);
            }
            else
            {
                IEnumerable<ggc> gg = new List<ggc> { new ggc() { xString = "gaa", xInt = 1 }, new ggc() { xString = "gbb", xInt = 2 } };
                return View("gg", gg);
            }
        }
        public ActionResult xx()
        {
            myLittleViewModel aa = new myLittleViewModel()
            {
                Date = "2017",
                randomID = "77566",
                examSubject = new List<examSubjects>(){
                    new examSubjects(){subject="aaaaa"},
                    new examSubjects(){subject="bbbbb"},
                    new examSubjects(){subject="ccccc"},
                    new examSubjects(){subject="ddddd"},
                    new examSubjects(){subject="eeeee"}
                }
            };
            return View(aa);
        }
        public ActionResult yy()
        {
            return View();
        }
        public class ggc
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "去你的擔擔麵")]
            [Display(Name = "名稱")]
            public string xString { get; set; }
            [Required(ErrorMessage = "去你的擔擔麵")]
            [Display(Name = "ggg")]
            public int xInt { get; set; }
        }
    }
}
