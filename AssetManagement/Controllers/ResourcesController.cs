using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AssetManagement.Data;
using AssetManagement.Models;
using AssetManagement.Models.AssetManagement;

namespace AssetManagement.Controllers
{
    public class ResourcesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Resources
        [Authorize(Roles = "Admin, Resource Checker")]
        public ActionResult Index()
        {
            var resources = db.Resources.Include(r => r.Facility);
            return View(resources.Where(r => r.IsActive == true).ToList());
        }

        // GET: Resources/Details/5
        [Authorize(Roles = "Admin, Resource Checker")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);

            Facility facility = db.Facilities.Find(resource.FacilityId);
            resource.FacilityName = facility.FacilityName;
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // GET: Resources/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.FacilityId = new SelectList(db.Facilities, "FacilityId", "FacilityName");
            return View();
        }

        // POST: Resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "ResourceId,ResourceName,Quantity,Description,Size,Color,FacilityId,UpdatedOn,IsActive")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                resource.UpdatedOn = DateTime.Now;
                resource.IsActive = true;
                db.Resources.Add(resource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacilityId = new SelectList(db.Facilities, "FacilityId", "FacilityName", resource.FacilityId);
            return View(resource);
        }

        // GET: Resources/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.FacilityId = new SelectList(db.Facilities, "FacilityId", "FacilityName", resource.FacilityId);
            return View(resource);
        }

        // POST: Resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ResourceId,ResourceName,Quantity,Description,Size,Color,FacilityId,UpdatedOn,IsActive")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                resource.UpdatedOn = DateTime.Now;
                resource.IsActive = true;
                db.Entry(resource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacilityId = new SelectList(db.Facilities, "FacilityId", "FacilityName", resource.FacilityId);
            return View(resource);
        }

        // GET: Resources/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);

            Facility facility = db.Facilities.Find(resource.FacilityId);
            resource.FacilityName = facility.FacilityName;

            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Resources/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resource resource = db.Resources.Find(id);
            resource.IsActive = false;
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
