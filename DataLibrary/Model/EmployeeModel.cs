using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Model
{
    //this is a front end User Interface Model (deferent from BisnessLogic/DataAccess Model)
    //this Model doesn't care about Display Names, Confirms Fields, etc., only the properties themselves
    public class EmployeeModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
