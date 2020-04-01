using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanTrackerV18.ViewModels
{//for use when displaying many workorders to housekeepers as UserLastName
    public class EditWorkOrderVM
    {
        
        [Required]
        [Display(Name = "Work Order Unit")]
        public string WorkOrderName { get; set; }

        public List<string> UserIds { get; set; }

        [Display(Name = "Users")]
        public MultiSelectList Users { get; set; }
    }
}

