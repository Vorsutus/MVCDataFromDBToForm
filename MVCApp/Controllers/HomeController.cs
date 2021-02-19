using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static DataLibrary.BusinessLogic.EmployeeProcessor;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //get data with this method
        public ActionResult SignUp()
        {
            ViewBag.Message = "Employee Sign Up.";

            return View();
        }
        
        //creating a view to display Employees
        public ActionResult ViewEmployees()
        {
            ViewBag.Message = "Employees List";

            //make a call to the method in business logic (Employee Processor) to return all the employees in the DB
            var data = LoadEmployees();

            //create a new List of employees following the Employee Model
            List<EmployeeModel> employees = new List<EmployeeModel>();

            //for each employee row in the Loaded Employees...
            foreach (var row in data)
            {
                //Add the new EmployeeModel with the following information to the employees list
                employees.Add(new EmployeeModel
                {
                    EmployeeId = row.EmployeeId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress
                });
            }

            //pass the employees into the View
            return View(employees);
        }


        //send data with this method
        [HttpPost]
        [ValidateAntiForgeryToken] //other half of the security token
        public ActionResult SignUp(EmployeeModel model)
        {
            //if all the lengths and rules on the form are valid...
            //never trust one layer of security, JS can be spoofed into believing it is valid data
            if (ModelState.IsValid)
            {
                //method in DataLibrary.BusinessLogic.EmployeeProcessor that communicated with SQL
                int recordsCreated = CreateEmployee(model.EmployeeId,
                                                       model.FirstName,
                                                       model.LastName,
                                                       model.EmailAddress);

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}