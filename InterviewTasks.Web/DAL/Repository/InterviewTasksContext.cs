using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTasks.Web.DAL.Domain;
using Microsoft.EntityFrameworkCore;

namespace InterviewTasks.Web.Repository
{
    public class InterviewTasksContext : DbContext
    {
        public InterviewTasksContext(DbContextOptions<InterviewTasksContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    } 
}
