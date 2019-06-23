using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InterviewTasks.Web.DAL.Domain;
using InterviewTasks.Web.DAL.Repository;
using InterviewTasks.Web.Repository;
using Newtonsoft.Json;

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

        public async Task<List<Contact>> GetAllAsync(Uri requestUri)
        {
            using (var client = new HttpClient())
            {
                var responseString = await client.GetStringAsync(requestUri);
                return JsonConvert.DeserializeObject<List<Contact>>(responseString);
            }
        }

        public void Delete(int id)
        {
            Context.Contacts.Remove(Get(id));
            Context.SaveChanges();
        }
    }
}
