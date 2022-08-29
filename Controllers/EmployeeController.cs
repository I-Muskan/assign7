using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assi7.Models;
namespace Assi7.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeContext empDb = new EmployeeContext();
        public ActionResult Index()
        {
            
           
            return View(empDb.EmployeeTable.ToList());
        }
        public ActionResult Details(int? empId)
        {
            
            //if (empId == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var employee = empDb.EmployeeTable.FirstOrDefault(x => x.EmpId == empId);
            //if (employee == null)
            //{
            //    return HttpNotFound();
            //}
            return View(employee);
        }
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string Name,string Gender,string City,decimal Salary,int DeptId)
        {

            Employee employee = new Employee();
            employee.Name = Name;
            employee.Gender = Gender;
            employee.City = City;
            employee.Salary = Salary;
            employee.DeptId = DeptId;


            empDb.EmployeeTable.Add(employee);
                empDb.SaveChanges();
                return RedirectToAction("Index");
           

         
        }
        public ActionResult Edit(int? empId)
        {
            //if (empId == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var employee = empDb.EmployeeTable.FirstOrDefault(x=>x.EmpId==empId);
            //if (employee == null)
            //{
            //    return HttpNotFound();
            //}
            return View(employee);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string Name, string Gender, string City, decimal Salary, int DeptId)
        {
            var item = empDb.EmployeeTable.FirstOrDefault(x => x.Name == Name);
            

                item.City = City;
                item.DeptId = DeptId;
                item.Gender = Gender;
                item.Name = Name;
                item.Salary = Salary;
                empDb.SaveChanges();
                return RedirectToAction("Index");
              

            
        

        }
        public ActionResult Delete(int? empId)
        {
            if (empId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = empDb.EmployeeTable.Find(empId);
         
            if (empId == null)
            {
                return HttpNotFound();
            }
            return View(employee);
            
        }

   
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int empId)
        {
            Employee employee = empDb.EmployeeTable.Find(empId);
            empDb.EmployeeTable.Remove(employee);
            empDb.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}