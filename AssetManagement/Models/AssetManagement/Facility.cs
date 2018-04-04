using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetManagement.Models.AssetManagement
{
    public class Facility : BaseEntity
    {
        public Facility()
        {
            Resources = new List<Resource>();
        }
        [Key]
        public int FacilityId { get; set; }

        [Required]
        [Display (Name = "Facility Name")]
        public string FacilityName { get; set; }

        public string Landmark { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [MaxLength(5)]
        [Display (Name = "Zip Code")]
        public string ZipCode { get; set; }

        public List<Resource> Resources { get; set; }

        [Required]
        public Boolean IsActive { get; set; }

        public ApplicationUser User { get; set; }
        public String UserId { get; set; }
    }

    public class AssignFacility
    {
        public String Name { get; set; }

        public int FacilityId { get; set; }

        public Boolean Assign { get; set; }
    }
}