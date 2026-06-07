using System;
using System.Collections.Generic;

namespace WorkHub.Domain.Entities
{
    public sealed class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Status { get; set; } = "New";
        public string? Assignee { get; set; }
        public DateTimeOffset? DueDate { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public Guid ProjectId { get; set; }
        public Project? Project { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
