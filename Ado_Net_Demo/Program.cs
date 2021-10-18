using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_Net_Demo
{
    public class Program
    {
      public static void Main(string[] args)
        {
            //Creating a object for employeerepository
            EmployeeRepository repository = new EmployeeRepository();
            repository.GetAllEmployee();
            //For adding employee
            EmployeeModel model = new EmployeeModel();
            model.EmployeeName = "Terissa";
            model.Department = "Sales";
            model.Salary = 3000000;
            repository.UpdateSalary(model);
            model.EmployeeName = "Bharat";
            model.TaxablePay = 12080;
            model.BasicPay = 1234805;
            model.Gender = "M";
            model.PhoneNumber = 9834516242;
            model.Address = "Rasayani";
            model.startDate = DateTime.Today;
            model.Department = "IT";
            model.Salary = 123456;
            repository.AddEmployee(model);
            Console.ReadLine();

        }
    }
}

