using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechJobs6Persistent.Data;
using TechJobs6Persistent.Models;
using TechJobs6Persistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobs6Persistent.Controllers
{
    public class JobController : Controller
    {
        private JobDbContext context;

        public JobController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }
        public IActionResult Add(int id)
        {
            //1. this method contains a list of employer objects pulled from SQL
            Job theJob = context.Jobs.Find(id);
            List<Employer> possibleEmployers = context.Employers.ToList();

            //2. this method creates an instance of AddJobViewModel
            AddJobViewModel viewModel = new AddJobViewModel(theJob, possibleEmployers);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(AddJobViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Employer theEmployer = context.Employers.Find(viewModel.EmployerId);
                Job newJob = new Job
                {
                    Name = viewModel.Name,
                    Employer = theEmployer,
                };

                context.Jobs.Add(newJob);
                context.SaveChanges();
                return Redirect("/Job");
            }
            return View(viewModel);
        }
        public IActionResult Delete()
        {
            ViewBag.jobs = context.Jobs.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] jobIds)
        {
            foreach (int jobId in jobIds)
            {
                Job theJob = context.Jobs.Find(jobId);
                context.Jobs.Remove(theJob);
            }

            context.SaveChanges();

            return Redirect("/Job");
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.Employer)
                .Include(j => j.Skills)
                .Single(j => j.Id == id);

            JobDetailViewModel jobDetailViewModel = new JobDetailViewModel(theJob);

            return View(jobDetailViewModel);
        }
    }
}

