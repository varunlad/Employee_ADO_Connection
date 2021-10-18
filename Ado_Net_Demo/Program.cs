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
            Console.ReadLine();

        }
    }
}

