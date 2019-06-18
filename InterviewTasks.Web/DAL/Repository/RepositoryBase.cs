using InterviewTasks.Web.Repository;

namespace InterviewTasks.Web.DAL.Repository
{
    public abstract class RepositoryBase
    {
        protected readonly InterviewTasksContext Context;

        protected RepositoryBase(InterviewTasksContext context)
        {
            this.Context = context;
        }
    }
}