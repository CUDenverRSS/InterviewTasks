using System.Linq;

namespace InterviewTasks.Web.Interfaces.Business
{
    public interface IBLL<T>
    {
        T Add(T model);
        T Update(T model);
        T Get(int id);
        IQueryable<T> GetAll();
    }
}