using System;
using System.Data;
using System.Data.SqlClient;

namespace Ado_Net_Demo
{
  public  class EmployeeRepository
    {
        //Connecting to Database
        public static string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=payRollService058;Integrated Security=True";
        //passing the string to sqlconnection to make connection 
        SqlConnection sqlconnection = new SqlConnection(connectionString);
        //GetAllEmployee method
        public void GetAllEmployee()
        {
            try
            {
                //Creating object for employeemodel and access the fields
                EmployeeModel employeeModel = new EmployeeModel();
                //Retrieve query
                string query = @"select * from employee_payRoll";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                //Open the connection
                this.sqlconnection.Open();
                //ExecuteReader: Returns data as rows.
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    { 
                        employeeModel.EmployeeId = Convert.ToInt32(reader["Employee_ID"] == DBNull.Value ? default : reader["Employee_ID"]);
                        employeeModel.EmployeeName = reader["Name"] == DBNull.Value ? default : reader["Name"].ToString();
                        employeeModel.Salary = Convert.ToDouble(reader["Salary"] == DBNull.Value ? default : reader["Salary"]);
                        employeeModel.startDate = (DateTime)(reader["Start_Date"] == DBNull.Value ? default(DateTime) : reader["Start_Date"]);
                        employeeModel.Gender = reader["Gender"] == DBNull.Value ? default : reader["Gender"].ToString();
                        employeeModel.Department = reader["Department"] == DBNull.Value ? default : reader["Department"].ToString();
                        employeeModel.PhoneNumber = Convert.ToDouble(reader["Phone"] == DBNull.Value ? default : reader["Phone"]);
                        employeeModel.Address = reader["Address"] == DBNull.Value ? default : reader["Address"].ToString();
                        employeeModel.Deductions = Convert.ToDouble(reader["Deduction"] == DBNull.Value ? default : reader["Deduction"]);
                        employeeModel.TaxablePay = Convert.ToDouble(reader["TaxablePay"] == DBNull.Value ? default : reader["TaxablePay"]);
                        employeeModel.BasicPay = Convert.ToDouble(reader["BasicPay"] == DBNull.Value ? default : reader["BasicPay"]);

                        Console.WriteLine("{0} {1} {2}  {3} {4} {5}  {6}  {7} {8} {9} {10}", employeeModel.EmployeeId, employeeModel.EmployeeName, employeeModel.PhoneNumber, employeeModel.Address, employeeModel.Department, employeeModel.Gender, employeeModel.Salary, employeeModel.Deductions, employeeModel.TaxablePay, employeeModel.BasicPay, employeeModel.startDate);
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("No data found");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
        }
        public void UpdateSalary(EmployeeModel model)
        {
            try
            {
                using (this.sqlconnection)
                {
                    EmployeeModel DisplayModel = new EmployeeModel();
                    SqlCommand command = new SqlCommand("dbo.spUpdateEmployeeDetails", this.sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", model.EmployeeName);
                    command.Parameters.AddWithValue("@Salary", model.Salary);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    sqlconnection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Update Sucessfull");
                    }
                    else
                    {
                        Console.WriteLine("Unsucessfull");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
        }
        public void AddEmployee(EmployeeModel model)
        {
            try
            {
                using (this.sqlconnection)
                {
                    SqlCommand command = new SqlCommand("dbo.SpAddEmployeeDetails1", this.sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", model.EmployeeName);
                    command.Parameters.AddWithValue("@Salary", model.Salary);
                    command.Parameters.AddWithValue("@Basepay", model.BasicPay);
                    command.Parameters.AddWithValue("@StartDate", model.startDate);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@Phone", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    sqlconnection.Open();
                    var result = command.ExecuteNonQuery();

                    if (result != 0)
                    {
                        Console.WriteLine("Successfully inserted the records");
                    }
                    else
                    {
                        Console.WriteLine("Insertion of result is unsuccessfull");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
        }
    }
}