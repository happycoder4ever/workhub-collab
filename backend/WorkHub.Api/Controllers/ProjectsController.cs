using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkHub.Application.DTOs;
using WorkHub.Application.Interfaces;

namespace WorkHub.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAll()
        {
            var projects = await _projectService.GetAllAsync();
            return Ok(projects);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProjectDto>> GetById(Guid id)
        {
            var project = await _projectService.GetByIdAsync(id);
            if (project is null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> Create(CreateProjectRequest request)
        {
            var project = await _projectService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProjectDto>> Update(Guid id, UpdateProjectRequest request)
        {
            var project = await _projectService.UpdateAsync(id, request);
            if (project is null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _projectService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
