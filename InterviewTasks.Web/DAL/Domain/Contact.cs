using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTasks.Web.DAL.Domain
{
    public class Contact : EntityBase
    {
        [Required(ErrorMessage = "The First Name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name is Required")]
        public string LastName { get; set; }
        
        [EmailAddress]
        [Required(ErrorMessage = "The Email Address is Required")]
        public string Email { get; set; }
        
        [Phone]
        [Required(ErrorMessage = "The Phone Number is Required")]
        public string PhoneNumber { get; set; }
    }
}
