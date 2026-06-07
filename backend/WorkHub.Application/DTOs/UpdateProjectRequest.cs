using System;

namespace WorkHub.Application.DTOs
{
    public sealed class UpdateProjectRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
