using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using InterviewTasks.Web.DAL.Domain;
using InterviewTasks.Web.Interfaces.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewTasks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactBLL<Contact> contactBll;

        public ContactsController(IContactBLL<Contact> contactBll)
        {
            this.contactBll = contactBll;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            return contactBll.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            var contact = contactBll.Get(id);
            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        [HttpPost]
        public ActionResult<Contact> Post([FromBody] Contact contact)
        {
            var createdContact = contactBll.Add(contact);
            return CreatedAtAction(nameof(Get), new {id = contact.Id }, createdContact);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            contactBll.Update(contact);

            return NoContent();
        }
    }
}
