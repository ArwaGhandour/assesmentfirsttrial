using Assesment.Models;
using Assesment.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDBContext _dbContext;
        public ProjectController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> GetAllProjects()
        {
            var pro = await _dbContext.Projects.ToListAsync();

            return View(pro);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            if (project == null)
            {
                return View(project);
            }
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("GetAllProjects");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var pro = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);
            return View(pro);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Project project)
        {
            if (project == null)
            {
                return View(project);
            }
            _dbContext.Projects.Update(project);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("GetAllProjects");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var pro = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);
            return View(pro);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Project project)
        {
            if (project == null)
            {
                return View(project);
            }
            _dbContext.Projects.Remove(project);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("GetAllProjects");
        }
        public async Task<IActionResult>Details(int id)
        {
            var det=await _dbContext.Projects.Include(x=>x.Tasks).FirstOrDefaultAsync(x=>x.Id==id);
            var tas = await _dbContext.Tasks.Include(x => x.teammember).ToListAsync();
            return View(det);
        }   

    }
}
