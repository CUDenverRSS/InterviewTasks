using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTasks.Web.DAL.Domain;
using InterviewTasks.Web.Interfaces.Repository;

namespace InterviewTasks.Web.Interfaces.Business
{
    public class ContactBLL : IContactBLL
    {
        private readonly IContactRepository contactRepository;

        public ContactBLL(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public Contact Add(Contact model)
        {
            return contactRepository.Add(model);
        }

        public Contact Update(Contact model)
        {
            return contactRepository.Update(model);
        }

        public Contact Get(int id)
        {
            return contactRepository.Get(id);
        }

        public IQueryable<Contact> GetAll()
        {
            return contactRepository.GetAll();
        }
    }
}
