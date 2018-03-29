using AssetManagement.Data;
using AssetManagement.Models.AssetManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssetManagement.Controllers
{
    public class ResourceInventoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Resources for the facility
        [Authorize(Roles = "Resource Checker")]
        public ActionResult Index(int id)
        {
            List<Resource> FacilityResources = db.Resources.Where(fr => fr.IsActive == true && fr.FacilityId == id).ToList();
            ResourceCheckList Inventory = new ResourceCheckList();
            Inventory.FacilityId = id;
            Inventory.ResourceList = new List<ResourceCheckViewModel>();
            foreach (var resource in FacilityResources)
            {
                ResourceCheckViewModel obj = new ResourceCheckViewModel()
                {
                    ResourceName = resource.ResourceName,
                    Color = resource.Color,
                    Description = resource.Description,
                    Size = resource.Size,
                    ResourceId = resource.ResourceId,
                    CurrentQuantity = resource.Quantity,
                    OriginalQuantity = resource.Quantity,
                    FacilityId = resource.FacilityId,
                    Comment = ""

                };
                Inventory.ResourceList.Add(obj);
            }
            return View(Inventory);
        }

        // POST: Save data to ResourceInventory table when Resource checker logs in and changes the quantities of resources
        [HttpPost]
        [Authorize(Roles = "Resource Checker")]
        public ActionResult Index(ResourceCheckList model)
        {
            foreach (var resource in model.ResourceList)
            {
                ResourceInventory record = new ResourceInventory
                {
                    ResourceId = resource.ResourceId,
                    CurrentQuantity = resource.CurrentQuantity,
                    Comment = resource.Comment,
                    UpdatedOn = DateTime.Now,
                    OriginalQuantity = resource.OriginalQuantity,
                    FacilityId = resource.FacilityId
                };
                db.ResourceInventories.Add(record);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Facilities", null);
        }
    }
}