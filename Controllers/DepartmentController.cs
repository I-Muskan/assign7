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
        public ActionResult Details(int? deptId)
        {
            if (deptId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                  Department department = empDb.DepartmentTable.Find(deptId);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeptId,DeptName")] Department department)
        {
            if (ModelState.IsValid)
            {
                empDb.DepartmentTable.Add(department);
                empDb.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }
        public ActionResult Edit(int? deptId)
        {
            if (deptId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = empDb.DepartmentTable.Find(deptId);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeptName")] Department department)
        {
            if (ModelState.IsValid)
            {
                empDb.Entry(department).State = EntityState.Modified;
                empDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }
    }
}