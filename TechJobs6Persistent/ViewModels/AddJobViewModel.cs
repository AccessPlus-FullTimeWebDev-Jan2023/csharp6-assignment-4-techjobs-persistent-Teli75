using Microsoft.AspNetCore.Mvc.Rendering;
using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels
{
    public class AddJobViewModel
    {
        public string? Name { get; set; }
        public int? EmployerId { get; set; }
        public List<SelectListItem>? Employers { get; set; }

        public AddJobViewModel(Job theJob, List<Employer> possibleEmployers)
        {
            Employers = new List<SelectListItem>();
            foreach (var employer in possibleEmployers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name,
                });
            }
        }
        public AddJobViewModel() 
        { 
        }
    }
}
