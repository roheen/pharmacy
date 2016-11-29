using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyManagementSystem
{
    public class DepartmentMedicineView
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int batchNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string EntryDate { get; set; }
        public string DepartmentName { get; set; }
        public int QuantityAssigned { get; set; }
    }
}