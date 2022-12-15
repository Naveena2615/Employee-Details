using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Employee_Details.Models;

namespace Employee_Details.Controllers
{
    public class EmployeeInfoesController : Controller
    {
        private tblEmployeeInfoEntities db = new tblEmployeeInfoEntities();

        // GET: EmployeeInfoes
        public ActionResult Index()
        {
            return View(db.EmployeeInfoes.ToList());
        }

        // GET: EmployeeInfoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeInfo employeeInfo = db.EmployeeInfoes.Find(id);
            if (employeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeInfo);
        }

        // GET: EmployeeInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,EmpName,EmpContact,EmpAddress,EmpDept")] EmployeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeInfoes.Add(employeeInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeInfo);
        }

        // GET: EmployeeInfoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeInfo employeeInfo = db.EmployeeInfoes.Find(id);
            if (employeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeInfo);
        }

        // POST: EmployeeInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,EmpName,EmpContact,EmpAddress,EmpDept")] EmployeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeInfo);
        }

        // GET: EmployeeInfoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeInfo employeeInfo = db.EmployeeInfoes.Find(id);
            if (employeeInfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeInfo);
        }

        // POST: EmployeeInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EmployeeInfo employeeInfo = db.EmployeeInfoes.Find(id);
            db.EmployeeInfoes.Remove(employeeInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
