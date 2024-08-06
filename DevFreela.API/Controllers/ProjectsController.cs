using DevFreela.API.Entities;
using DevFreela.API.Models;
using DevFreela.API.Persistence;
using DevFreela.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        public ProjectsController(DevFreelaDbContext context)
        {
            _context = context;
        }

        // GET api/projects?search=crm
        [HttpGet]
        public IActionResult Get(string searchs = "")
        {
            var projects = _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Include(p => p.Comments)
                .Where(p => !p.IsDeleted);
            var model = projects.Select(ProjectItemViewModel.FromEntity);

            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var project = _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Include(p => p.Comments)
                .SingleOrDefault(p => p.Id == id);

            var model = ProjectItemViewModel.FromEntity(project);

            return Ok(model);
        }


        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {
            var project = model.ToEntity();

            _context.Projects.Add(project);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = project.Id}, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProjectInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if(project is null)
            {
                return NotFound();
            }

            project.Update(model.Title, model.Description, model.TotalCost);
            _context.Projects.Update(project);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if(project is null)
            {
                return NotFound();
            }

            project.SetAsDeleted();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if(project is null)
            {
                return NotFound();
            }

            project.Start();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == id);
            if(project is null)
            {
                return NotFound();
            }

            project.Complete();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(CreateProjectCommentInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(p => p.Id == model.IdProject);
            if(project is null)
            {
                return NotFound();
            }

            var comment = new ProjectComment(model.Content, model.IdProject, model.IdUser);
            
            _context.Comments.Add(comment);
            _context.SaveChanges();

            return NoContent();

        }

    }
}
