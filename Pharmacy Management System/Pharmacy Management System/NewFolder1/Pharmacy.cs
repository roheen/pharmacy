using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PharmacyManagementSystem
{
    public class Pharmacy
    {
        private string _userName;
        private PharmacySQLDataHelper _sqlHelper;
        public Pharmacy(string userName)
        {
            _userName = userName;
            _sqlHelper = new PharmacySQLDataHelper(_userName);
        }
        public bool GetUser(string password)
        {
            bool isValidUser = _sqlHelper.GetUser(password);
            return isValidUser;
        }

        public void SignUP(UserDataView userView)
        {
            _sqlHelper.SignUp(userView);
        }
        public List<MedicineView> GetMedicinesAjax()
        {
           List<MedicineView> medicinesList = new List<MedicineView>();
           DataTable dataTable= _sqlHelper.GetMedicinesAjax();
           for (int index = 0; index < dataTable.Rows.Count; index++)
           {
               MedicineView medicine = new MedicineView();
               medicine.Name = dataTable.Rows[index]["Name"].ToString();
               medicine.Quantity = (int)dataTable.Rows[index]["Quantity"];
               medicine.batchNumber = (string)dataTable.Rows[index]["BatchNumber"];
               medicine.EntryDate = ((DateTime)(dataTable.Rows[index]["EntryDate"])).ToString("MMMM dd, yyyy");
               medicine.ExpiryDate = ((DateTime)dataTable.Rows[index]["ExpiryDate"]).ToString("MMMM dd, yyyy");
               medicine.medicineID = (int)dataTable.Rows[index]["ID"];
               medicine.AvaiableQuantity = (int)dataTable.Rows[index]["AvailableQuantity"];              
               medicinesList.Add(medicine);
           }
           return medicinesList;
        }

        public List<string> GetAllMedicineNames()
        {
            List<string> medicinesList = new List<string>();
            DataTable dataTable = _sqlHelper.GetAllMedicineNames();
            for (int index = 0; index < dataTable.Rows.Count; index++)
            {              
                medicinesList.Add(dataTable.Rows[index]["Name"].ToString());
            }
            return medicinesList;
        }
        public List<string> GetAllDepartmentNames()
        {
            List<string> medicinesList = new List<string>();
            DataTable dataTable = _sqlHelper.GetAllDepartmentNames();
            for (int index = 0; index < dataTable.Rows.Count; index++)
            {
                medicinesList.Add(dataTable.Rows[index]["DepartmentName"].ToString());
            }
            return medicinesList;
        }
        public void AddDepartmentAgainstMedicine(DepartmentMedicineView medicine)
        {
            _sqlHelper.AddDepartmentAgainstMedicine(medicine);
        }
        public void AddMedicine(MedicineView medicine)
        {
            _sqlHelper.AddMedicine(medicine);
        }
        public void EditMedicine(MedicineView medicine)
        {
            _sqlHelper.EditMedicine(medicine);
        }

        public void DeleteMedicine(int medicineID)
        {
            _sqlHelper.DeleteMedicine(medicineID);
        }
        public List<MedicineReportView> GetMedicineMonthlyReport(string medicineView)
        {
            DataTable dataTable = _sqlHelper.GetMedicineMonthlyReport(medicineView);
           List<MedicineReportView> medicinesList = new List<MedicineReportView>();
           for (int index = 0; index < dataTable.Rows.Count; index++)
           {
               MedicineReportView medicine = new MedicineReportView();
               medicine.medicineName = dataTable.Rows[index]["MedicineName"].ToString();
               medicine.quantityAssigned = (int)dataTable.Rows[index]["QuantityAssigned"];
               medicine.batchNumber = (string)dataTable.Rows[index]["BatchNumber"];
               medicine.allocationDate = ((DateTime)(dataTable.Rows[index]["AllocationDate"])).ToString("MMMM dd, yyyy");
               medicine.departmentName = (dataTable.Rows[index]["DepartmentName"]).ToString();
               medicinesList.Add(medicine);
           }
           return medicinesList;

        }
        public void AddDepartmentAjax(String departmentName)
        {
            _sqlHelper.AddDepartment(departmentName);
        }

        public List<DepartmentView> ViewAllDepartments()
        {
            DataTable dataTable = _sqlHelper.ViewAllDepartments();
            List<DepartmentView> departmentList = new List<DepartmentView>();
            for (int index = 0; index < dataTable.Rows.Count; index++)
            {
                DepartmentView department = new DepartmentView();

                department.departmentName = dataTable.Rows[index]["DepartmentName"].ToString();
                department.departmentID = (int)dataTable.Rows[index]["ID"];

                departmentList.Add(department);
            }
            return departmentList;
        }
        public List<MedicineReportView> GetMedicineMovingRate(string medicineName)
        {
            DataTable dataTable = _sqlHelper.GetMedicineMovingRate(medicineName);
            List<MedicineReportView> medicineList = new List<MedicineReportView>();
            for (int index = 0; index < dataTable.Rows.Count; index++)
            {
                MedicineReportView medicine = new MedicineReportView();
                //medicine.allocationDate = dataTable.Rows[index]["AllocationDate"].ToString().Split(' ')[0];
                medicine.allocationDate = dataTable.Rows[index]["AllocationDate"].ToString();
                medicine.departmentName = dataTable.Rows[index]["DepartmentName"].ToString();
                medicine.quantityAssigned = (int)dataTable.Rows[index]["QuantityAssigned"];
                medicine.medicineName = medicineName;
                medicineList.Add(medicine);
            }
            return medicineList;
        }
        public void DeleteDepartment(string departmentID)
        {
            _sqlHelper.DeleteMedicine(departmentID);
        }

        public List<MedicineView> GetEsentialMedicines()
        {
            DataTable dataTable = _sqlHelper.GetEsentialMedicines();
            List<MedicineView> medicinesList = new List<MedicineView>();
            for (int index = 0; index < dataTable.Rows.Count; index++)
            {
                MedicineView medicine = new MedicineView();
               
                medicine.Name = dataTable.Rows[index]["Name"].ToString();
                medicine.Quantity = (int)dataTable.Rows[index]["Quantity"];
                medicine.batchNumber = (string)dataTable.Rows[index]["BatchNumber"];
                medicine.EntryDate = ((DateTime)(dataTable.Rows[index]["EntryDate"])).ToString("MMMM dd, yyyy");
                medicine.ExpiryDate = ((DateTime)dataTable.Rows[index]["ExpiryDate"]).ToString("MMMM dd, yyyy");
                medicine.medicineID = (int)dataTable.Rows[index]["ID"];
                medicine.AvaiableQuantity = (int)dataTable.Rows[index]["AvailableQuantity"];
                medicinesList.Add(medicine);
            }
            return medicinesList;

        }
        public List<MedicineView> GetAggingStockAjax()
        {
            DataTable dataTable = _sqlHelper.GetAggingStockAjax();
            List<MedicineView> medicinesList = new List<MedicineView>();
            for (int index = 0; index < dataTable.Rows.Count; index++)
            {
                MedicineView medicine = new MedicineView();

                medicine.Name = dataTable.Rows[index]["Name"].ToString();
                medicine.Quantity = (int)dataTable.Rows[index]["Quantity"];
                medicine.batchNumber = (string)dataTable.Rows[index]["BatchNumber"];
                medicine.EntryDate = ((DateTime)(dataTable.Rows[index]["EntryDate"])).ToString("MMMM dd, yyyy");
                medicine.ExpiryDate = ((DateTime)dataTable.Rows[index]["ExpiryDate"]).ToString("MMMM dd, yyyy");
                medicine.medicineID = (int)dataTable.Rows[index]["ID"];
                medicine.AvaiableQuantity = (int)dataTable.Rows[index]["AvailableQuantity"];
                medicinesList.Add(medicine);
            }
            return medicinesList;

        }
    }
}