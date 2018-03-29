using AssetManagement.Data;
using AssetManagement.Models.AssetManagement;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetManagement.Controllers
{
    
    public class FacilityReportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FacilityReport
        [Authorize(Roles = "Admin")]
        public ActionResult FacilityReport()
        {
            List<ResourceInventory> latestResourceReports = new List<ResourceInventory>();
            latestResourceReports = db.ResourceInventories.GroupBy(x => x.ResourceId, (key, g) => g.OrderByDescending(e => e.UpdatedOn).FirstOrDefault()).ToList();
            //abnormalFacilities = db.ResourceInventories.Where(ri => ri.CurrentQuantity != ri.OriginalQuantity).Select(ri => ri.FacilityId).Distinct().ToList();
            List<int> abnormalFacilities = latestResourceReports.Where(f=>f.CurrentQuantity!=f.OriginalQuantity).Select(i=>i.FacilityId).ToList();
            List<Facility> Facilities = db.Facilities.Where(f => f.IsActive == true).ToList();
            List<FacilityReportViewModel> ReportFacilities = new List<FacilityReportViewModel>();
            
            foreach (var item in Facilities)
            {
                FacilityReportViewModel obj = new FacilityReportViewModel()
                {
                    FacilityId = item.FacilityId,
                    FacilityName = item.FacilityName,
                    Address = item.Address,
                    Landmark = item.Landmark,
                    City = item.City,
                    State = item.State,
                    ZipCode = item.ZipCode,
                };
                foreach (var abFacilityId in abnormalFacilities)
                {
                    if (abFacilityId == item.FacilityId)
                    {
                        obj.IsAbnormal = true;
                        
                    }
                    else
                    {
                        obj.IsAbnormal = false;
                    }
                }
                ReportFacilities.Add(obj);
            }
            return View(ReportFacilities);
        }

        //GET: facility resource details
        [Authorize(Roles = "Admin")]
        public ActionResult ResourceDetailReport(int id)
        {
            List<ResourceInventory> ResourceDetails = db.ResourceInventories.Where(ri => ri.FacilityId == id).GroupBy(x => x.ResourceId, (key, g) => g.OrderByDescending(e => e.UpdatedOn).FirstOrDefault()).ToList();
            //List<ResourceInventory> ResourceDetails = db.ResourceInventories.Where(ri => ri.FacilityId == id).ToList();
            List<ResourceDetailReportViewModel> ResourceReport = new List<ResourceDetailReportViewModel>();

            foreach (var detail in ResourceDetails)
            {
                Resource resource = db.Resources.Find(detail.ResourceId);
                ResourceDetailReportViewModel obj = new ResourceDetailReportViewModel()
                {
                    ResourceId = detail.ResourceId,
                    CurrentQuantity = detail.CurrentQuantity,
                    OriginalQuantity = db.Resources.Find(resource.ResourceId).Quantity,
                    Description = resource.Description,
                    Size = resource.Size,
                    Color = resource.Color,
                    ResourceName = resource.ResourceName,
                    Comment = detail.Comment
                };
                ResourceReport.Add(obj);
            }
            return View(ResourceReport);
        }

        // Update quantities to database
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateDatabase(int id, int currentQuantity, int originalQuantity)
        {
            Resource resource = db.Resources.Find(id);
            resource.Quantity = currentQuantity;
            resource.UpdatedOn = DateTime.Now;
            db.SaveChanges();

            ResourceInventory record = new ResourceInventory()
            {
                ResourceId = id,
                CurrentQuantity = currentQuantity,
                OriginalQuantity = currentQuantity,
                Comment = "Verified and Updated by Admin",
                UpdatedOn = DateTime.Now,
                FacilityId = resource.FacilityId
            };
            db.ResourceInventories.Add(record);
            db.SaveChanges();
            return RedirectToAction("FacilityReport");
        }
    }
}