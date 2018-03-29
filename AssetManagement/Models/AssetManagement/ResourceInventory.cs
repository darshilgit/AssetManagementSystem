using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetManagement.Models.AssetManagement
{
    public class ResourceInventory : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public int OriginalQuantity { get; set; }

        [Required]
        public int CurrentQuantity { get; set; }

        [Required]
        [StringLength(200)]
        public string Comment { get; set; }

        public int FacilityId { get; set; }
        public Facility Facility { get; set; }

        public int ResourceId { get; set; }
        public Resource Resource { get; set; }
    }

    public class ResourceCheckViewModel
    {
        [Required]
        public int CurrentQuantity { get; set; }

        public int FacilityId { get; set; }

        public int OriginalQuantity { get; set; }

        [Required]
        [StringLength(200)]
        public string Comment { get; set; }

        [Key]
        public int ResourceId { get; set; }

        [Required]
        [Display(Name = "Resource Name")]
        public string ResourceName { get; set; }

        [Required]
        public string Description { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }
    }

    public class ResourceCheckList
    {
        [Key]
        public int FacilityId { get; set; }
        public List<ResourceCheckViewModel> ResourceList { get; set; }
    }
}