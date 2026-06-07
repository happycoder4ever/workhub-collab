using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkHub.Application.Interfaces;
using WorkHub.Domain.Entities;
using WorkHub.Infrastructure.Data;

namespace WorkHub.Infrastructure.Repositories
{
    public sealed class ProjectRepository : IProjectRepository
    {
        private readonly WorkHubDbContext _dbContext;

        public ProjectRepository(WorkHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.AsNoTracking().ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Projects.FindAsync(id);
        }

        public async Task<Project> AddAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);
            return project;
        }

        public async Task DeleteAsync(Project project)
        {
            _dbContext.Projects.Remove(project);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
