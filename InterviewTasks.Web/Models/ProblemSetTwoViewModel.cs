using System.ComponentModel.DataAnnotations;

namespace InterviewTasks.Web.Models
{
    public class ProblemSetTwoViewModel
    {
        [Required(ErrorMessage = "A number is required")]
        [Display(Name = "First Number")]
        [Range(0, 999999999999999, ErrorMessage = "Please use a number between 0 and 999999999999999")]
        public double? NumberOne { get; set; }
        [Required(ErrorMessage = "A number is required")]
        [Display(Name = "Second Number")]
        [Range(0, 999999999999999, ErrorMessage = "Please use a number between 0 and 999999999999999")]
        public double? NumberTwo { get; set; }
        public double? Sum { get; set; }
    }
}