using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanTrackerV18.Models.CleanTracker
{
    public partial class Services
    {
        public Services()
        {
            WorkOrders = new HashSet<WorkOrders>();
        }


        [HiddenInput(DisplayValue = false)] 
        public int ServiceId { get; set; }

        [Display(Name = "Service Name")]
        public string ServiceType { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public double ServicePrice { get; set; }

        [Display(Name = "Cost")]
        [DataType(DataType.Currency)]
        public double? ServiceCost { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime? ServiceLastModified { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ServiceLastModifiedBy { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool? ServiceIsActive { get; set; }

        public virtual ICollection<WorkOrders> WorkOrders { get; set; }
    }
}
