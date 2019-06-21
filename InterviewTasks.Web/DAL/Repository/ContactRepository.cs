using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTasks.Web.DAL.Domain;
using InterviewTasks.Web.DAL.Repository;
using InterviewTasks.Web.Repository;

namespace InterviewTasks.Web.Interfaces.Repository
{
    public class ContactRepository : RepositoryBase, IContactRepository
    {
        public ContactRepository(InterviewTasksContext context) : base(context)
        {
        }

        public Contact Add(Contact model)
        {
            Context.Contacts.Add(model);
            Context.SaveChanges();
            return model;
        }

        public Contact Update(Contact model)
        {
            Context.Contacts.Update(model);
            Context.SaveChanges();
            return model;
        }

        public Contact Get(int id)
        {
            return Context.Contacts.Find(id);
        }

        public IQueryable<Contact> GetAll()
        {
            return Context.Contacts;
        }
    }
}
