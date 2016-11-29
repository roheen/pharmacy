using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PharmacyManagementSystem;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Pharmacy_Management_System.Controllers
{
    public class DepartmentController : Controller
    {
        private Pharmacy pharmacy;
        string _userName;
        //
        // GET: /Department/
        public ActionResult AddDepartment()
        {
            return View();
        }

        public ActionResult AddDepartmentAjax(String Name)
        {
            pharmacy = new Pharmacy(_userName);
            pharmacy.AddDepartmentAjax(Name);
            return RedirectToAction("ViewAllDepartments", "Department");    
        }
        public ActionResult ViewAllDepartments()
        {
            return View();
        }
        public JsonResult ViewAllDepartmentsAjax()
        {
            pharmacy = new Pharmacy(_userName);
            List<DepartmentView> lstDepartments=pharmacy.ViewAllDepartments();
            var serealized = JsonConvert.SerializeObject(lstDepartments);
            return this.Json(serealized, JsonRequestBehavior.AllowGet);
        }
        public void DeleteDepartment(string departmentId)
        {
            pharmacy = new Pharmacy(_userName);
            pharmacy.DeleteDepartment(departmentId);       
        }

	}
}