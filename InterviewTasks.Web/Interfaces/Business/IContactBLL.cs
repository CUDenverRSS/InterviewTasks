using InterviewTasks.Web.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterviewTasks.Web.Interfaces.Business
{
    public interface IContactBLL<Contact> : IBLL<Contact>
    {
        Task<List<Contact>> GetAllAsync(Uri requestUri);
    }
}