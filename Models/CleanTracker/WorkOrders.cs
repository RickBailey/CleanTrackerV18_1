using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanTrackerV18.Models.CleanTracker
{
    public partial class WorkOrders
    {
        [HiddenInput(DisplayValue = false)]
        public int WorkOrderId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? UserId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? UnitId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? ServiceId { get; set; }

        [Display(Name ="Number")]
        public int? WorkOrderNumber { get; set; }

        [Display(Name = "Unit")]
        public string WorkOrderName { get; set; }

        [Display(Name = "Service")]
        public string WorkOrderServiceType { get; set; }

        [Display(Name = "Status")]
        public string WorkOrderCompletionStatus { get; set; }

        [Display(Name = "Assigned To")]
        public string WorkOrderAssign { get; set; }

        [Display(Name = "Date")]
        public DateTime? WorkOrderLastModified { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string WorkOrderLastModifiedBy { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool? WorkOrderIsActive { get; set; }

        public ICollection<WorkOrderUser> WorkOrderUsers { get; set; }



        [HiddenInput(DisplayValue = false)]
        public virtual Services Service { get; set; }

        [HiddenInput(DisplayValue = false)]
        public virtual Units Unit { get; set; }

        [HiddenInput(DisplayValue = false)]
        public virtual Users User { get; set; }
    }
}
