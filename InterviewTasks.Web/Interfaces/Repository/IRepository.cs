using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTasks.Web.Interfaces.Repository
{
    public interface IRepository<T>
    {
        T Add(T model);
        T Update(T model);
        T Get(int id);
        IQueryable<T> GetAll();
        Task<List<T>> GetAllAsync(Uri requestUri);
        void Delete(int id);
    }
}