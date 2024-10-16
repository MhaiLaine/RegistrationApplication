using RegistrationApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace RegistrationApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RegistrationPage()
        {
            return View();
        }

        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }
        

        public JsonResult ThreeFunction(RegistrationModel registrationData) //jsonresult return type is json
        {
            //first way
            //var firstName = registrationData.FirstName;

            //registrationData.Username = "sdasd";
            //registrationData.Password = "hkhkhkjhkjh";

            //second way
            var rModel = new RegistrationModel()
            {
                FirstName = registrationData.FirstName,
                MiddleName = registrationData.MiddleName,
                LastName = registrationData.LastName,
                Address = registrationData.Address,
                Email = registrationData.Email,
                phoneNumber = registrationData.phoneNumber,
                Username = registrationData.FirstName + "." + registrationData.LastName,
                Password = registrationData.Password

            }; //new -> bagong instance

            return Json(rModel, JsonRequestBehavior.AllowGet); //always allowget
        }

        //manggagaling yung username and password sa CS papuntang controller.JS USING MODEL



    }
}
