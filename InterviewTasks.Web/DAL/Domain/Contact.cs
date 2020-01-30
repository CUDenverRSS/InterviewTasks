using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTasks.Web.DAL.Domain
{
    public class Contact : EntityBase
    {
        public string FirstName { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
  public int Foo { get; set; }
    }
}
