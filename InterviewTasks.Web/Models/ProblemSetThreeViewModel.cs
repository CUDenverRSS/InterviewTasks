using System.Collections.Generic;
using InterviewTasks.Web.DAL.Domain;

namespace InterviewTasks.Web.Models
{
    public class ProblemSetThreeViewModel
    {
        public Contact NewContact { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}