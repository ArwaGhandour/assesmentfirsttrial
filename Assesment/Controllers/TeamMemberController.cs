using Assesment.Models.ViewModel;
using Assesment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assesment.Models.Entities;

namespace Assesment.Controllers
{
    public class TeamMemberController : Controller
    {
        private readonly AppDBContext _dbContext;
        public TeamMemberController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult>Details(int id)
        {
            var det = await _dbContext.TeamMembers.Include(x => x.Tasks).FirstOrDefaultAsync(x => x.Id == id);
            return View(det);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var pro = await _dbContext.TeamMembers.FirstOrDefaultAsync(x => x.Id == id);
            return View(pro);
        }
        [HttpPost]
        public async Task<IActionResult> Update(TeamMember tm)
        {
            if (tm == null)
            {
                return View(tm);
            }
            _dbContext.TeamMembers.Update(tm);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("GetAllProjects","Project");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var pro = await _dbContext.TeamMembers.FirstOrDefaultAsync(x => x.Id == id);
            return View(pro);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(TeamMember tm)
        {
            if (tm == null)
            {
                return View(tm);
            }
            _dbContext.TeamMembers.Remove(tm);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("GetAllProjects", "Project");
        }
    }
}
