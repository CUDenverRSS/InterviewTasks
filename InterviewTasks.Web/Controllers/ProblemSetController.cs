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
        private readonly IContactBLL contactBll;

        public ProblemSetController(IContactBLL contactBll)
        {
            this.contactBll = contactBll;
        }

        // Tell the user which validation rules to add to the Entity Model.
        // Pull down the source from git as part of the exercise.



        /// <summary>
        /// ProblemSetOne is missing its Action Method.
        /// 1. Add Problem Set One's method
        /// 2. Add a property to the ProblemSetOneViewModel to display "Hello MVC" on the view.
        /// </summary>
        /// <returns></returns>
        public IActionResult ProblemSetOne()
        {
            var model = new ProblemSetOneViewModel();
            model.Message = "Hello World";
            return View(model);
        }

        /// <summary>
        /// Create an adding calculator.
        /// 1. Update ProblemSetTwoViewModel to have three integer properties: Num1, Num2, and Sum.
        /// 2. Add a form to the page with two inputs for Num1 and Num2.
        /// 3. Create a Post Method that will add Num1 and Num2 and store it in Sum.
        /// 4. Return the updated value to the page so that we can see the result.
        /// </summary>
        /// <returns></returns>
        public IActionResult ProblemSetTwo()
        {
            var model = new ProblemSetTwoViewModel();
            model.Num1 = 0;
            model.Num2 = 0;
            model.Sum = 0;
            return View(model);
        }

        [HttpPost]
        public IActionResult ProblemSetTwo(ProblemSetTwoViewModel model)
        {
            model.Sum = model.Num1 + model.Num2;
            return View(model);
        }

        /// <summary>
        /// For Problem Set Three, you will be performing operations on a contact list.
        /// 1. Use the API to load all contacts. Make sure they loaded in the view.
        /// 2. Add a new ActionResult to add a new contact to the table.  Make sure it has server-side validation.
        /// 3. We want to start recording the last name for each contact.  Add this property to the Contact.
        /// 3.a. Update the Entity Framework Migration to track this new property.
        /// 3.b. Update the UI to include this input in the form.
        /// 4. Write an ajax call to delete a Contact.
        /// 4.a. The delete functionality is not implemented for this api call.  Implement it.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ProblemSetThree()
        {
            var model = new ProblemSetThreeViewModel();

            var client = new HttpClient();
            client.BaseAddress = new Uri($"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}");
            var contacts = await client.GetStringAsync("/api/Contacts/");

            model.Contacts = JsonConvert.DeserializeObject<List<Contact>>(contacts);
            return View(model);
        }

        [HttpPost]
        public IActionResult ProblemSetThree(ProblemSetThreeViewModel model)
        {
            if (ModelState.IsValid)
            {
                contactBll.Add(model.NewContact);
                return RedirectToAction(nameof(ProblemSetThree));
            }

            model.Contacts = contactBll.GetAll().ToList();
            return View(model);
        }

        public IActionResult DeleteContact(int id)
        {
            var contact = contactBll.Get(id);
            contactBll.Delete(contact);

            return RedirectToAction(nameof(ProblemSetThree));
        }

        /// <summary>
        /// api.weather.gov will allow you to pull in a detailed weather forecast.
        /// Documentation can be found here: https://www.weather.gov/documentation/services-web-api
        /// 1. Make this api call, to get the data as a json string.
        /// 2. Use Newtonsoft.Json to deserialize this data as a ForecastDTO
        /// 3. Add the forecast to the model
        /// API Call: https://api.weather.gov/gridpoints/BOU/62,61/forecast
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ProblemSetFour()
        {
            var model = new ProblemSetFourViewModel();

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.weather.gov/");
            client.DefaultRequestHeaders.Add("User-Agent", "WeatherTasksAppCUAnschutz");
            var jsonForecast = await client.GetStringAsync("gridpoints/BOU/62,61/forecast");

            model.Forecast = JsonConvert.DeserializeObject<ForecastDTO>(jsonForecast);

            return View(model);
        }
    }
}
