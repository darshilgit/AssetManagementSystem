using AssetManagement.Models;
using AssetManagement.Models.AssetManagement;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AssetManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceInventory> ResourceInventories { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<AssetManagement.Models.AssetManagement.ResourceCheckViewModel> ResourceCheckViewModels { get; set; }

        public System.Data.Entity.DbSet<AssetManagement.Models.AssetManagement.ResourceCheckList> ResourceCheckLists { get; set; }
    }
}