using InterviewTasks.Web.DAL.Domain;

namespace InterviewTasks.Web.Interfaces.Repository
{
    public interface IContactRepository : IRepository<Contact>
    {
        void Delete(Contact contact);
    }
}