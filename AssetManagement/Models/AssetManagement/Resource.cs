using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetManagement.Models.AssetManagement
{
    public class Resource: BaseEntity
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [Display (Name = "Resource Name")]
        public string ResourceName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Description { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        [Required]
        public Boolean IsActive { get; set; }

        public int FacilityId { get; set; }

        [Display (Name = "Facility Name")]
        public string FacilityName { get; set; }

        public Facility Facility { get; set; }

    }
}