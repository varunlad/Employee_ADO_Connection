using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_Net_Demo
{
  public  class EmployeeModel
    {
        //Getter and setter fields(present in db)
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public double PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }
        public double Deductions { get; set; }
        public double TaxablePay { get; set; }
        public double BasicPay { get; set; }
        public DateTime startDate { get; set; }
    }
}
