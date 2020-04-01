using CleanTrackerV18.Models.CleanTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanTrackerV18.Models
{
    public class WorkOrderUser
    {

        public int WorkOrderId { get; set; }
        public WorkOrders WorkOrder { get; set;}

        public int UserId { get; set; }
        public Users Users { get; set; }


    }
}
