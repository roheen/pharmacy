using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Pharmacy_Management_System.Models;
using PharmacyManagementSystem;

namespace Pharmacy_Management_System.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            UserDataView userView = new UserDataView();
            userView.UserName = Request["userName"].ToString();
            userView.password = Request["password"].ToString();
            userView.email = Request["email"].ToString();
            userView.Name = Request["name"].ToString();
            Pharmacy pharmacy = new Pharmacy(userView.UserName);
            pharmacy.SignUP(userView);
            Session["UserName"] = userView.UserName;
            return RedirectToAction("index", "Home");
        }
       


        


    }
}