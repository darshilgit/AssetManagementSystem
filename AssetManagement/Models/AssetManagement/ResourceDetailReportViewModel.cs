using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetManagement.Models.AssetManagement
{
    public class ResourceDetailReportViewModel
    {
        public int ResourceId { get; set; }
        
        [Display(Name = "Resource Name")]
        public string ResourceName { get; set; }
        
        public string Description { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        [Display(Name = "Original Quantity")]
        public int OriginalQuantity { get; set; }

        [Display(Name = "Current Quantity")]
        public int CurrentQuantity { get; set; }

        public string Comment { get; set; }
    }
}