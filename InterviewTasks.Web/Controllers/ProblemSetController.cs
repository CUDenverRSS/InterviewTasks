using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InterviewTasks.Web.DAL.Domain;
using InterviewTasks.Web.Interfaces.Business;
using InterviewTasks.Web.Models;
using InterviewTasks.Web.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace InterviewTasks.Web.Controllers
{
    public class ProblemSetController : Controller
    {
        private IContactBLL<Contact> _contactBLL;
        public ProblemSetController(IContactBLL<Contact> contactBLL)
        {
            this._contactBLL = contactBLL;
        }

        /// <summary>
        /// ProblemSetOne is missing its Action Method.
        /// 1. Add Problem Set One's method
        /// 2. Pass a message from the server to the client such as 'hello mvc'
        /// </summary>
        /// 
        public ActionResult ProblemSetOne()
        {
            var model = new ProblemSetOneViewModel() { OutString = "hello mvc" };
            return View(model);
        }

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

        [HttpPost]
        public ActionResult ProblemSetTwo(ProblemSetTwoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var sum = vm.NumberOne + vm.NumberTwo;
            vm.Sum = sum;
            return View(vm);
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
        public async Task<ActionResult> ProblemSetThree()
        {
            var model = new ProblemSetThreeViewModel();
            var uri = new Uri($"{Request.Scheme}://{Request.Host}{Request.PathBase}/api/contacts");
            model.Contacts = await _contactBLL.GetAllAsync(uri);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ProblemSetThree(ProblemSetThreeViewModel vm)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.PathBase}/api/Contacts");
                if (!ModelState.IsValid)
                {
                    vm.Contacts = await _contactBLL.GetAllAsync(url);
                    return View(vm);
                }                
                var json = JsonConvert.SerializeObject(vm.NewContact);
                using (var response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")))
                {
                    response.EnsureSuccessStatusCode();
                }
                ModelState.Clear();
                var model = new ProblemSetThreeViewModel();
                model.Contacts = await _contactBLL.GetAllAsync(url);
                return View(model);
            }
        }

        public ActionResult DeleteContact(int id)
        {
            _contactBLL.Delete(id);
            return RedirectToAction("ProblemSetThree");
        }

        /// <summary>
        /// api.weather.gov will allow you to pull in a detailed weather forecast.
        /// Documentation can be found here: https://www.weather.gov/documentation/services-web-api
        /// 1. Make an api call to get the weather info for Denver.
        /// 2. Pass this data to the front end using model.Forecast
        /// API Call: https://api.weather.gov/gridpoints/BOU/62,61/forecast
        /// </summary>
        public async Task<IActionResult> ProblemSetFour()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "UOCInterview");
            var responseString = await client.GetStringAsync(new Uri($"https://api.weather.gov/gridpoints/BOU/62,61/forecast"));
            var model = new ProblemSetFourViewModel();
            model.Forecast = JsonConvert.DeserializeObject<ForecastDTO>(responseString);
            return View(model);
        }
    }
}