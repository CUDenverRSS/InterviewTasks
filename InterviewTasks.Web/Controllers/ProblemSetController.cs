using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InterviewTasks.Web.DAL.Domain;
using InterviewTasks.Web.Interfaces.Business;
using InterviewTasks.Web.Models;
using InterviewTasks.Web.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InterviewTasks.Web.Controllers
{
    public class ProblemSetController : Controller
    {
        public ProblemSetController()
        {
        }

        /// <summary>
        /// ProblemSetOne is missing its Action Method.
        /// 1. Add Problem Set One's method
        /// 2. Pass a message from the server to the client such as 'hello mvc'
        /// </summary>


        /// <summary>
        /// Create an adding calculator.
        /// Create a form with two numeric inputs.  When the form is submitted,
        /// the sum of the two numbers should be displayed on the page.
        /// </summary>
        public IActionResult ProblemSetTwo()
        {
            var model = new ProblemSetTwoViewModel();
            return View(model);
        }

        /// <summary>
        /// For Problem Set Three, you will be performing operations on a contact list.
        /// 1. Use the API to load all contacts. Make sure they are displayed in the view.
        /// 2. Add a form to add a new contact to the table. Use the ContactBLL's Add Method to save it to the database.
        /// 3. Add validation to the database model. All fields should be required.  Make sure a valid email and phone number are used.
        /// 3. We want to start recording the last name for each contact.
        /// 3.a. Add this property to the Contact.
        /// 3.b. Update the Entity Framework Migration to track this new property.
        /// 3.c. Update the UI to include this input in the form.
        /// 4. We want to delete contacts that are no longer needed.
        /// 4.a. Add the ability to delete a contact in the table.  Display a confirmation before the record is deleted.
        /// 4.b. Implement the delete functionality within the business logic.
        /// </summary>
        public IActionResult ProblemSetThree()
        {
            var model = new ProblemSetThreeViewModel();
            return View(model);
        }

        /// <summary>
        /// api.weather.gov will allow you to pull in a detailed weather forecast.
        /// Documentation can be found here: https://www.weather.gov/documentation/services-web-api
        /// 1. Make an api call to get the weather info for Denver.
        /// 2. Pass this data to the front end using model.Forecast
        /// API Call: https://api.weather.gov/gridpoints/BOU/62,61/forecast
        /// </summary>
        public IActionResult ProblemSetFour()
        {
            var model = new ProblemSetFourViewModel();
            return View(model);
        }
    }
}
