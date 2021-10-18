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
        
    }
}