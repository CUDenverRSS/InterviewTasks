using System.Linq;

namespace InterviewTasks.Web.Interfaces.Repository
{
    public interface IRepository<T>
    {
        T Add(T model);
        T Update(T model);
        T Get(int id);
        IQueryable<T> GetAll();
    }
}