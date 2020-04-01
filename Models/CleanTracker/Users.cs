using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanTrackerV18.Models.CleanTracker
{
    public partial class Users
    {
        public Users()
        {
            WorkOrders = new HashSet<WorkOrders>();
        }

        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }

        [Display(Name = "First Name")]
        public string UserFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string UserLastName { get; set; }

        [Display(Name = "Role")]
        public string UserType { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered format is not valid.")]
        public string UserPhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string UserEmailAddress { get; set; }

        [Display(Name = "Date Entered")]
        public DateTime? UserLastModified { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserLastModifiedBy { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool? UserIsActive { get; set; }

        public virtual ICollection<WorkOrders> WorkOrders { get; set; }

        public ICollection<WorkOrderUser> WorkOrderUsers { get; set; }
    }
}
