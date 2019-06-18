using InterviewTasks.Web.DAL.Domain;

namespace InterviewTasks.Web.Interfaces.Business
{
    public interface IContactBLL : IBLL<Contact>
    {
        void Delete(Contact contact);
    }
}