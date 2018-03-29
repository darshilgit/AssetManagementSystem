using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagement.Models.AssetManagement
{
    public class FacilityReportViewModel
    {
        public int FacilityId { get; set; }

        public string FacilityName { get; set; }

        public string Landmark { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public bool IsAbnormal { get; set; }

    }
}