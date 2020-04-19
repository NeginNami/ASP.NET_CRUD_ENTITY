using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_CRUD_ENTITY.Models;

namespace ASP.NET_CRUD_ENTITY.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View("Index",GetEmployeeList());
        }
        public ActionResult AddOrEditEmployee(Employee emp)
        {
            
                using (mvcCrudDb db = new mvcCrudDb())
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();
                }
            return Content("Success");
        }
        public ActionResult RenderAddEmployee()
        {
            Employee emp = new Employee();
            return PartialView("Add",emp);
        }
        public List<Employee> GetEmployeeList()
        {
            using (mvcCrudDb db = new mvcCrudDb())
            {
                List<Employee> empList = db.Employees.ToList<Employee>();
                return empList;
            }
        }
    }
}