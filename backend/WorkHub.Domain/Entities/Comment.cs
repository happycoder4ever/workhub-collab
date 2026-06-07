using System;

namespace WorkHub.Domain.Entities
{
    public sealed class Comment
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public TaskItem? Task { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; }
    }
}
