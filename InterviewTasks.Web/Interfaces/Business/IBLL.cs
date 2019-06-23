using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTasks.Web.Interfaces.Business
{
    public interface IBLL<T>
    {
        T Add(T model);
        T Update(T model);
        T Get(int id);
        IQueryable<T> GetAll();
        void Delete(int id);
    }
}