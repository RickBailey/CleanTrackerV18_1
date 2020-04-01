using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanTrackerV18.Models.CleanTracker
{
    public partial class Units
    {
        public Units()
        {
            WorkOrders = new HashSet<WorkOrders>();
        }

        [HiddenInput(DisplayValue = false)]
        public int UnitId { get; set; }

        [Display(Name = "Unit Number")]
        public string UnitName { get; set; }

        [Display(Name = "Size")]
        public string UnitType { get; set; }

        [Display(Name = "Section")]
        public string UnitNeighborhood { get; set; }

        [Display(Name = "Status")]
        public string UnitStatus { get; set; }

        [Display(Name = "Date Entered")]
        public DateTime? UnitLastModified { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UnitLastModifiedBy { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool? UnitIsActive { get; set; }

        public virtual ICollection<WorkOrders> WorkOrders { get; set; }
    }
}
