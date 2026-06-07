using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkHub.Domain.Entities;

namespace WorkHub.Application.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(Guid id);
        Task<Project> AddAsync(Project project);
        Task DeleteAsync(Project project);
        Task SaveChangesAsync();
    }
}
