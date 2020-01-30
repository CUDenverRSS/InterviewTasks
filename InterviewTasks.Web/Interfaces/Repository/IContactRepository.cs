using InterviewTasks.Web.DAL.Domain;
using System.Linq;

namespace InterviewTasks.Web.Interfaces.Repository
{
    public interface IContactRepository : IRepository<Contact>
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        IQueryable<Contact> GetAll();
    }
}