using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AssetManagement.Data;
using AssetManagement.Models;
using AssetManagement.Models.AssetManagement;
using Microsoft.AspNet.Identity;

namespace AssetManagement.Controllers
{
    public class FacilitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        // GET: Facilities
        [Authorize(Roles = "Admin, Resource Checker")]
        public ActionResult Index()
        {
            var user = System.Web.HttpContext.Current.User.Identity.GetUserId();
            if (User.IsInRole("Admin"))
            {
                return View(db.Facilities.Where(f => f.IsActive == true).ToList());
            }
            else
            {
                return View(db.Facilities.Where(f => f.IsActive == true && f.UserId == user).ToList());
            }
            
        }

        public ActionResult ResourcesList(int id)
        {
            var relatedResources = db.Facilities.Include(r => r.Resources).SingleOrDefault(f => f.FacilityId == id);
            return View(relatedResources);
        }

        // GET: Facilities/Details/5
        [Authorize(Roles = "Admin, Resource Checker")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facility facility = db.Facilities.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            return View(facility);
        }

        // GET: Facilities/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "FacilityId,FacilityName,Landmark,Address,City,State,ZipCode,UpdatedOn,IsActive")] Facility facility)
        {
            if (ModelState.IsValid)
            {
                facility.UpdatedOn = DateTime.Now;
                facility.IsActive = true;
                db.Facilities.Add(facility);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(facility);
        }

        // GET: Facilities/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facility facility = db.Facilities.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            return View(facility);
        }

        // POST: Facilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "FacilityId,FacilityName,Landmark,Address,City,State,ZipCode,UpdatedOn,IsActive")] Facility facility)
        {
            if (ModelState.IsValid)
            {
                facility.UpdatedOn = DateTime.Now;
                facility.IsActive = true;
                db.Entry(facility).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facility);
        }

        // GET: Facilities/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facility facility = db.Facilities.Find(id);
            if (facility == null)
            {
                return HttpNotFound();
            }
            return View(facility);
        }

        // POST: Facilities/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facility facility = db.Facilities.Find(id);
            List<Resource> resources = db.Resources.Where(r => r.FacilityId == id).ToList();
            foreach (var resource in resources)
            {
                resource.IsActive = false;
            }
            facility.IsActive = false;
            //db.Facilities.Remove(facility);
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
