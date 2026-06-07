using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkHub.Application.DTOs;
using WorkHub.Application.Interfaces;
using WorkHub.Domain.Entities;

namespace WorkHub.Application.Services
{
    public sealed class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            var projects = await _projectRepository.GetAllAsync();
            return projects.Select(MapToDto);
        }

        public async Task<ProjectDto?> GetByIdAsync(Guid id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            return project is null ? null : MapToDto(project);
        }

        public async Task<ProjectDto> CreateAsync(CreateProjectRequest request)
        {
            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTimeOffset.UtcNow
            };

            await _projectRepository.AddAsync(project);
            await _projectRepository.SaveChangesAsync();
            return MapToDto(project);
        }

        public async Task<ProjectDto?> UpdateAsync(Guid id, UpdateProjectRequest request)
        {
            var existing = await _projectRepository.GetByIdAsync(id);
            if (existing is null)
            {
                return null;
            }

            existing.Name = request.Name;
            existing.Description = request.Description;
            await _projectRepository.SaveChangesAsync();
            return MapToDto(existing);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _projectRepository.GetByIdAsync(id);
            if (existing is null)
            {
                return false;
            }

            await _projectRepository.DeleteAsync(existing);
            await _projectRepository.SaveChangesAsync();
            return true;
        }

        private static ProjectDto MapToDto(Project project)
        {
            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CreatedAt = project.CreatedAt
            };
        }
    }
}
