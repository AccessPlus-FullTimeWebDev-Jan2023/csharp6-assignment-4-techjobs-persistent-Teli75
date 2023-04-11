using System.ComponentModel.DataAnnotations;

namespace TechJobs6Persistent.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required(ErrorMessage ="Please include a name")]
        [StringLength(20, MinimumLength = 2)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please include a location")]
        [StringLength(20, MinimumLength = 2)] 
        public string? Location { get; set; }


    }
}
