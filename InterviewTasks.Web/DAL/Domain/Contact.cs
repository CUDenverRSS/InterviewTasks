using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTasks.Web.DAL.Domain
{
    public class Contact : EntityBase
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Invalid Phone Number.")]
        [Required(ErrorMessage = "Phone Number is required.")]
        public string PhoneNumber { get; set; }
    }
}
