using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PharmacyManagementSystem;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Pharmacy_Management_System.Controllers
{
    public class UserController : Controller
    {
        private Pharmacy pharmacy;
        string _userName;
        public ActionResult ViewAllUsers()
        {
            return View();
        }
        public JsonResult ViewAllUsersAjax()
        {
            pharmacy = new Pharmacy(_userName);
            List<UserDataView> lstUsers = pharmacy.ViewAllUsers();
            var serealized = JsonConvert.SerializeObject(lstUsers);
            return this.Json(serealized, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddUser()
        {
            return View();
        }

        public ActionResult AddUserAjax(String Name)
        {
            pharmacy = new Pharmacy(_userName);
            pharmacy.AddDepartmentAjax(Name);
            return RedirectToAction("ViewAllDepartments", "Department");
        }
        public void DeleteUser(int userID)
        {
            pharmacy = new Pharmacy(_userName);
            pharmacy.DeleteUser(userID);
        }
    }
}