using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyManagementSystem
{
    public class MedicineReportView
    {
        public string medicineName { get; set; }
        public string departmentName { get; set; }
        public string allocationDate { get; set; }
        public int quantityAssigned { get; set; }           
        public string batchNumber { get; set; }
       
    }
}