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
    public class DepartmentController : Controller
    {
        // GET: Department
        EmployeeContext empDb = new EmployeeContext();
      
        public ActionResult Index()
        {
            return View(empDb.DepartmentTable.ToList());
        }

        public ActionResult Details(int deptId)
        {
            var item = empDb.DepartmentTable.FirstOrDefault(x => x.DeptId == deptId);
            return View(item);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public RedirectResult Create(Department dept)
        {
            empDb.DepartmentTable.Add(dept);
            empDb.SaveChanges();
            return Redirect("/Department/Index");
        }

        public ActionResult Edit(int deptId)
        {
            var item = empDb.DepartmentTable.FirstOrDefault(x => x.DeptId == deptId);
            return View(item);
        }

        [HttpPost]

        public RedirectResult Edit(Department dept)
        {
            var item = empDb.DepartmentTable.FirstOrDefault(x => x.DeptId == dept.DeptId);
            item.DeptName = dept.DeptName;
            empDb.SaveChanges();
            return Redirect("/Department/Index");
        }

        public ActionResult Delete(int deptId)
        {
            var item = empDb.DepartmentTable.FirstOrDefault(x => x.DeptId == deptId);
            return View(item);
        }

        [HttpPost]

        public RedirectResult ConfirmDelete(int deptId)
        {
            var item = empDb.DepartmentTable.FirstOrDefault(x => x.DeptId == deptId);
            empDb.DepartmentTable.Remove(item);
            empDb.SaveChanges();
            return Redirect("/Department/Index");
        }
    }

}