using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkHub.Application.DTOs;

namespace WorkHub.Application.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAllAsync();
        Task<ProjectDto?> GetByIdAsync(Guid id);
        Task<ProjectDto> CreateAsync(CreateProjectRequest request);
        Task<ProjectDto?> UpdateAsync(Guid id, UpdateProjectRequest request);
        Task<bool> DeleteAsync(Guid id);
    }
}
