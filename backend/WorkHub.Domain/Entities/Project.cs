using System;
using System.Collections.Generic;

namespace WorkHub.Domain.Entities
{
    public sealed class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
