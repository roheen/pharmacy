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
    public class ReportController : Controller
    {
        private Pharmacy pharmacy;
        string _userName;
        //
        // GET: /Report/
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetMonthlyMedicineReport(string medicineName)
        {
            pharmacy = new Pharmacy(_userName);
            List<MedicineReportView> medicines = pharmacy.GetMedicineMonthlyReport(medicineName);
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var serealized = JsonConvert.SerializeObject(medicines);
            return this.Json(serealized, JsonRequestBehavior.AllowGet);
        }
	}
}