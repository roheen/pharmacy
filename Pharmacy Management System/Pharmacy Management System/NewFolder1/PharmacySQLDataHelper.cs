using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace PharmacyManagementSystem
{
    public class PharmacySQLDataHelper
    {
        private string _userName;
        string _connetionString = null;
        SqlConnection _connection;
        public PharmacySQLDataHelper(string userName)
        {
            _userName = userName;
            _connetionString = "Server=d1bd9b58-a553-4b57-9e96-a6cb01292ada.sqlserver.sequelizer.com;Database=dbd1bd9b58a5534b579e96a6cb01292ada;User ID=ygewhklojjpokbmj;Password=ezq8EaDypUchzSNS7c4TTBNRg3jzMrxm2zEhJF76TTMFvtgLS2JwiTKJUGZKYeT7;";
            _connection = new SqlConnection(_connetionString);
        }
        public bool GetUser(string password)
        {
            bool isValidUser = false;
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.GetUser", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userName", _userName);
                cmd.Parameters.AddWithValue("@password", password);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                    isValidUser = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to get the required user because " + exception.Message);
            }
            return isValidUser;
        }

        public void SignUp(UserDataView userData)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.AddUser", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userName", userData.UserName);
                cmd.Parameters.AddWithValue("@password", userData.password);
                cmd.Parameters.AddWithValue("@name", userData.Name);
                cmd.Parameters.AddWithValue("@email", userData.email);
                cmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to get the required user because " + exception.Message);
            }
        }

        public DataTable GetMedicinesAjax()
        {
            DataTable dataTable = new DataTable();
            //try
            //{
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.GetALLMedicines", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine("Failed to get the required user because " + exception.Message);
            //}
            return dataTable;
        }

        public DataTable GetAllMedicineNames()
        {
            DataTable dataTable = new DataTable();
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.GetALLMedicineNames", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to get Medicine names because " + exception.Message);
            }
            return dataTable;
        }

        public DataTable GetAllDepartmentNames()
        {
            DataTable dataTable = new DataTable();
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.GetAllDepartments", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to get Department names because " + exception.Message);
            }
            return dataTable;
        }
        public void AddMedicine(MedicineView medicine)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.AddMedicine", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@medicineName", medicine.Name);
                cmd.Parameters.AddWithValue("@quantity", medicine.Quantity);
                cmd.Parameters.AddWithValue("@entryDate", medicine.EntryDate);
                cmd.Parameters.AddWithValue("@expiryDate", medicine.ExpiryDate);
                cmd.Parameters.AddWithValue("@batchNumber", medicine.batchNumber);
                cmd.Parameters.AddWithValue("@isEssential", medicine.isEssential);
                cmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to get Medicine names because " + exception.Message);
            }
        }
        public void AddDepartmentAgainstMedicine(DepartmentMedicineView medicine)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.AssignMedicinetoDepartment", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@medicineName", medicine.Name);
                cmd.Parameters.AddWithValue("@departmentName", medicine.DepartmentName);
                cmd.Parameters.AddWithValue("@qantityAssigned", medicine.QuantityAssigned);
                cmd.Parameters.AddWithValue("@allotmentDate", DateTime.Today);
                cmd.Parameters.AddWithValue("@batchNumber", medicine.batchNumber);
                cmd.Parameters.AddWithValue("@expiryDate", medicine.ExpiryDate);
                cmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to get Medicine names because " + exception.Message);
            }
        }

        public void EditMedicine(MedicineView medicine)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.UpdateMedicine", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@medicineID", medicine.medicineID);
                cmd.Parameters.AddWithValue("@medicineName", medicine.Name);
                cmd.Parameters.AddWithValue("@qantity", Convert.ToInt32(medicine.Quantity));
                cmd.Parameters.AddWithValue("@entryDate", medicine.EntryDate);
                cmd.Parameters.AddWithValue("@availableQuantity",Convert.ToInt32(medicine.AvaiableQuantity));
                cmd.Parameters.AddWithValue("@expiryDate", medicine.ExpiryDate);
                cmd.Parameters.AddWithValue("@batchNumber", medicine.batchNumber);
                cmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to get Medicine names because " + exception.Message);
            }
        }
        public void AddDepartment(String departmentName)
        {
            _connection.Open();
            SqlCommand cmd = new SqlCommand("dbo.AddDepartment", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
            cmd.ExecuteNonQuery();
        }

        public void DeleteMedicine(string departmentID)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.DeleteDepartment", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentID", departmentID); 
                cmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to get Monthly Report because " + exception.Message);
            }
        }

        public DataTable GetMedicineMovingRate(string medicineName)
        {
            DataTable dataTable = new DataTable();
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.MovingRateMedicines", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@medicineName", medicineName);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to get Medine Report due to " + exception.Message);
            }
            return dataTable;
        }
        public DataTable ViewAllDepartments()
        {
            DataTable dataTable = new DataTable();
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.GetAllDepartment", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@medicineName", medicineName);
                //cmd.Parameters.AddWithValue("@fromDate", FromDate);
                //cmd.Parameters.AddWithValue("@toDate", ToDate);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to get Monthly Report because " + exception.Message);
            }
            return dataTable;
        }
        public DataTable GetMedicineMonthlyReport(string medicineName)
        {
            DataTable dataTable = new DataTable();
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.GetMedicineMonthlyReport", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@medicineName", medicineName);
                //cmd.Parameters.AddWithValue("@fromDate", FromDate);
                //cmd.Parameters.AddWithValue("@toDate", ToDate);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to get Monthly Report because " + exception.Message);
            }
            return dataTable;
        }
        public void DeleteMedicine(int medicineID)
        {
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.DeleteMedicine", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@medicineID", medicineID);          
                cmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to get Medicine names because " + exception.Message);
            }
        }
        public DataTable GetEsentialMedicines()
        {
            DataTable dataTable = new DataTable();
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.GetEssentialMedicines", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to get Medicine names because " + exception.Message);
            }
            return dataTable;
        }

        public DataTable GetAggingStockAjax()
        {
            DataTable dataTable = new DataTable();
            try
            {
                _connection.Open();
                SqlCommand cmd = new SqlCommand("dbo.GetAgingStock", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Failed to get Medicine names because " + exception.Message);
            }
            return dataTable;
        }
    }
}