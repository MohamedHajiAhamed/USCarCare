using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using USCarCare.Models;

namespace USCarCare.Controllers
{
    public class tbl_serviceController : Controller
    {
        private Model2 db = new Model2();

        // GET: tbl_service
        public ActionResult Index()
        {
            return View(db.tbl_service.ToList());
        }

        // GET: tbl_service/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_service tbl_service = db.tbl_service.Find(id);
            if (tbl_service == null)
            {
                return HttpNotFound();
            }
            return View(tbl_service);
        }

        // GET: tbl_service/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_service/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Car_Brand,Car_Model,Car_Type,Car_Registration_Number,Service_Type,Special_Request")] tbl_service tbl_service)
        {
            if (ModelState.IsValid)
            {
                db.tbl_service.Add(tbl_service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_service);
        }

        // GET: tbl_service/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_service tbl_service = db.tbl_service.Find(id);
            if (tbl_service == null)
            {
                return HttpNotFound();
            }
            return View(tbl_service);
        }

        // POST: tbl_service/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Car_Brand,Car_Model,Car_Type,Car_Registration_Number,Service_Type,Special_Request")] tbl_service tbl_service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_service);
        }

        // GET: tbl_service/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_service tbl_service = db.tbl_service.Find(id);
            if (tbl_service == null)
            {
                return HttpNotFound();
            }
            return View(tbl_service);
        }

        // POST: tbl_service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_service tbl_service = db.tbl_service.Find(id);
            db.tbl_service.Remove(tbl_service);
            db.SaveChanges();
            return RedirectToAction("~/Home/Service_Request");
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
