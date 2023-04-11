using TechJobs6Persistent.Models;

namespace TechJobs6Persistent.ViewModels
{
    public class AddJobViewModel
    {
        public string? Name { get; set; }
        public int? EmployerId { get; set; }
        public List<Employer>? Employers { get; set; }
    }
}
