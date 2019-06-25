using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace InterviewTasks.Web.DAL.Domain
{
    public class Contact : EntityBase
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z'@']{1,40}")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z'@']{1,40}")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{7,10}")]
        public string PhoneNumber { get; set; }
    }
}
