using AspNetCoreGeneratedDocument;
using Assesment.Models;
using Assesment.Models.Entities;
using Assesment.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDBContext _dbContext;
        public TaskController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var t = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.id == id);
            var pro = await _dbContext.Projects.ToListAsync();
            var teamemb=await _dbContext.TeamMembers.ToListAsync();
            TaskViewModel tvm = new TaskViewModel()
            {
                projects = pro,
                teammembers = teamemb,
                projectidd = t.ProjectIDD,
                teammembIDD=t.Teammemberidd,
                tvmId=t.id,
                title=t.Title,
                description=t.Description,
                status=t.statues,
                priority=t.Priority
            };

            return View(tvm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(TaskViewModel tvm,int id)
        {
            var t = await _dbContext.Tasks.Include(x=>x.teammember).FirstOrDefaultAsync(x => x.id == id);
            if(tvm == null)
            {
                return View(tvm);
            }
            t.ProjectIDD=tvm.projectidd;
            t.Teammemberidd=tvm.teammembIDD;
            t.Title=tvm.title;
            t.Description=tvm.description;
            t.statues = tvm.status;
            t.Priority = tvm.priority;

            _dbContext.Tasks.Update(t);
            await _dbContext.SaveChangesAsync();
            return View("Views_Project_GetAllProjects");
        }
       



    }
}
