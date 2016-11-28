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
    public class HomeController : Controller
    {
        private Pharmacy pharmacy;
        string _userName;
        public ActionResult Index()
        {
            try
            {
                if (Request["userName"].ToString() == null)
                    return RedirectToAction("Login", "Account");
            }catch(Exception e)
            {
                return RedirectToAction("Login", "Account");
            }
            _userName = Request["userName"].ToString();
            string password = Request["password"].ToString();
            pharmacy=new Pharmacy(_userName);
            bool isValidUser=pharmacy.GetUser(password);
            if (isValidUser)
                Session["UserName"] = _userName;
            else
                return RedirectToAction("Login", "Account");
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

        public ActionResult ViewAllMedicines()
        {
            return View();
        }
        public JsonResult GetMedicinesAjax()
        {
            pharmacy = new Pharmacy(_userName);
            List<MedicineView> medicines=pharmacy.GetMedicinesAjax();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var serealized = JsonConvert.SerializeObject(medicines);
            return this.Json(serealized,JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult AddMedicine(MedicineView medicine)
        {
           
            pharmacy = new Pharmacy(_userName);
            pharmacy.AddMedicine(medicine);
            return RedirectToAction("ViewAllMedicines","Home");
        }
        public void DeleteMedicine(string medicineID)
        {
            pharmacy = new Pharmacy(_userName);
            pharmacy.DeleteMedicine(Convert.ToInt32(medicineID));
        }
        public JsonResult GetAllMedicineNames()
        {
            pharmacy = new Pharmacy(_userName);
            List<string> lstMedicines = pharmacy.GetAllMedicineNames();
            return this.Json(lstMedicines, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllDepartmentNames()
        { 
            pharmacy = new Pharmacy(_userName);
            List<string> lstDepartments = pharmacy.GetAllDepartmentNames();
            return this.Json(lstDepartments, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AssignMedicinetoDepartment()
        {
            string medicineString=Request["selectedMedicine"].ToString();
            string[] medicineArray = medicineString.Split(',');
            MedicineView medicine = new MedicineView();
            medicine.Name=medicineArray[0];
            medicine.Quantity = Convert.ToInt32(medicineArray[1]);
            medicine.batchNumber = Convert.ToString(medicineArray[2]);
            medicine.EntryDate = medicineArray[3] + "," + medicineArray[4];
            medicine.ExpiryDate = medicineArray[5] + "," + medicineArray[6];
            medicine.medicineID = Convert.ToInt32(medicineArray[7]);
            medicine.AvaiableQuantity = Convert.ToInt32(medicineArray[8]);
            return View(medicine);
        }
        public ActionResult AddDepartmentAgainstMedicine(DepartmentMedicineView medicine)
        {
            pharmacy = new Pharmacy(_userName);
            pharmacy.AddDepartmentAgainstMedicine(medicine);
            return RedirectToAction("ViewAllMedicines", "Home");
        }
        public ActionResult EditMedicine(MedicineView medicine)
        {
            pharmacy = new Pharmacy(_userName);
            pharmacy.EditMedicine(medicine);
            return RedirectToAction("ViewAllMedicines", "Home");
        }
        public ActionResult GetEsentialMedicines()
        {           
            return View();
        }
        public JsonResult GetEsentialMedicinesAjax()
        {
            pharmacy = new Pharmacy(_userName);
            List<MedicineView> medicineList=pharmacy.GetEsentialMedicines();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var serealized = JsonConvert.SerializeObject(medicineList);
            return this.Json(serealized, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MedicineMovingRate()
        {
            return View();
        }

        public JsonResult GetMedicineMovingRate(string medicineName)
    {
        pharmacy = new Pharmacy(_userName);
        List<MedicineReportView> medicineList = pharmacy.GetMedicineMovingRate(medicineName);
        var serealized = JsonConvert.SerializeObject(medicineList);
        return this.Json(serealized, JsonRequestBehavior.AllowGet);
    }
        public ActionResult GetAggingStock()
        {
            return View();
        }
        public JsonResult GetAggingStockAjax()
        {
            pharmacy = new Pharmacy(_userName);
            List<MedicineView> medicineList = pharmacy.GetAggingStockAjax();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var serealized = JsonConvert.SerializeObject(medicineList);
            return this.Json(serealized, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Test()
        {
            return View();
        }
      
    }
}