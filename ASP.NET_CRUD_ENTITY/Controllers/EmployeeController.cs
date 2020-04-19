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
        public ActionResult DeleteEmployee(string employeeId)
        {
            Employee emp = new Employee {EmployeeId= Convert.ToInt32(employeeId) };
            using (mvcCrudDb db = new mvcCrudDb())
            {
                db.Employees.Attach(emp);
                db.Employees.Remove(emp);
                db.SaveChanges();
            }

            return Content("Success");
        }

        public ActionResult DeleteSelectedEmployee(List<string> employeeIds)
        {
            for (int i = 0; i < employeeIds.Count; i++)
            {
                Employee emp = new Employee { EmployeeId = Convert.ToInt32(employeeIds[i]) };
                using (mvcCrudDb db = new mvcCrudDb())
                {
                    db.Employees.Attach(emp);
                    db.Employees.Remove(emp);
                    db.SaveChanges();
                }
            }
            return Content("Success");
        }
        //public Employee GetEmployee(int EmployeeId)
        //{
        //    Employee emp = new Employee();
        //    using (mvcCrudDb db = new mvcCrudDb())
        //    {
        //        var data = db.Employees.Where(x => x.EmployeeId == EmployeeId)
        //              .Select(x => new Employee { EmployeeId = x.EmployeeId, EmployeeName = x.EmployeeName, 
        //                  EmployeeEmail = x.EmployeeEmail, EmployeePhone = x.EmployeePhone, EmployeeAddress= x.EmployeeAddress });
        //        emp = data.FirstOrDefault();

        //    }
        //    return emp;
        //}
        public ActionResult RenderAddEmployee()
        {
            Employee emp = new Employee();
            return PartialView("Add",emp);
        }
        public ActionResult RenderDeleteEmployee(string employeeId)
        {
            Employee emp = new Employee();
            emp.EmployeeId = Convert.ToInt32( employeeId);
            return PartialView("Delete", emp);
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