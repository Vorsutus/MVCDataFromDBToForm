using DataLibrary.DataAccess;
using DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    //also not storing data (not instantiating), so can be made static
    public static class EmployeeProcessor
    {
        //Mapping our data from one EmployeeModel to the other
        public static int CreateEmployee(int employeeId, string firstName, string lastName, string emailAddress)
        {
            EmployeeModel data = new EmployeeModel
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress
            };

            //parameterized sql, @ indicates a parameter
            string sql = @"insert into dbo.Employee (EmployeeId, FirstName, LastName, EmailAddress)
                        values (@EmployeeId, @FirstName, @LastName, @EmailAddress);";

            //return our sql statement and our data
            return SQLDataAccess.SaveData(sql, data);
        }

        //load the employees from the DataLibrary Employees and pass them up the chain
        public static List<EmployeeModel> LoadEmployees()
        {
            string sql = @"select Id, EmployeeId, FirstName, LastName, EmailAddress
                            from dbo.Employees;";

            //loading all employees back to the Database
            return SQLDataAccess.LoadData<EmployeeModel>(sql);
        }
    }
}
