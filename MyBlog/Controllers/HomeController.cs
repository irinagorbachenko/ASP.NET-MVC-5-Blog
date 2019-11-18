using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyBlog.Controllers
{   //Controller for a Form Model.
    public class HomeController : Controller
    {
       

        public ActionResult Form(Form form)
        {
            

            if (HttpContext.Request.HttpMethod == "POST")
            {
                
                return View("~/Views/Home/TestResult.cshtml", form);
            }
            else
            {
                return View(form);
             
            }
        }

    }

}
