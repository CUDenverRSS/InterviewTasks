using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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

        public IActionResult ProblemSetOne()
        {
            var model = new ProblemSetOneViewModel();
            return View(model);
        }

        /// <summary>
        /// Problem Set Two is missing its Action Method.
        /// 1. Add Problem Set Two's method
        /// 2. Add a property to the ProblemSetTwoViewModel to display "Hello MVC" on the view.
        /// </summary>
        /// <returns></returns>
        public IActionResult ProblemSetTwo()
        {
            var model = new ProblemSetTwoViewModel();
            return View(model);
        }

        /// <summary>
        /// api.weather.gov will allow you to pull in a detailed weather forecast.
        /// 1. Make this api call, to get the data as a json string.
        /// 2. Use Newtonsoft.Json to deserialize this data as a ForecastDTO
        /// 3. Add the forecast to the model
        /// API Call: https://api.weather.gov/gridpoints/BOU/62,61/forecast
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ProblemSetThree()
        {
            var model = new ProblemSetThreeViewModel();

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.weather.gov/");
            client.DefaultRequestHeaders.Add("User-Agent", "WeatherTasksAppCUAnschutz");
            var jsonForecast = await client.GetStringAsync("gridpoints/BOU/62,61/forecast");

            model.Forecast = JsonConvert.DeserializeObject<ForecastDTO>(jsonForecast);

            return View(model);
        }
    }
}
