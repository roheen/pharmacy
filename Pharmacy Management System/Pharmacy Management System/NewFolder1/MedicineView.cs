using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyManagementSystem
{
    public class MedicineView
    {
        public int medicineID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int AvaiableQuantity { get; set; }     
        public string ExpiryDate { get; set; }
        public string EntryDate { get; set; }
        public string batchNumber { get; set; }
        public bool isEssential { get; set; }
    }
}