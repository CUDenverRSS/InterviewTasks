using System.Collections.Generic;
using InterviewTasks.Web.Controllers;

namespace InterviewTasks.Web.Models.DTOs
{
    public class ForecastDTO
    {
        public PropertyDTO Properties { get;set; }
        
    }

    public class PropertyDTO
    {
        public List<PeriodDTO> Periods { get;set; }
    }
}