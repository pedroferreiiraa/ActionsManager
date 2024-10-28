using _5W2H.Core.Entities;
using _5W2H.Core.Enums;
using System.Collections.Generic;
using System.Linq;

namespace _5W2H.Application.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public int ProjectNumber { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public int UserId { get; private set; }
        public string OriginDate { get; private set; }

        public DateTime? CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        
        public string Description { get; private set; }
        
        // Somente os IDs das ações
        public List<int> ActionIds { get; private set; }

        public string Origin { get; private set; }
        public int OriginNumber { get; private set; }
        
        public string? ConclusionText { get; private set; }
        
        // Método ToEntity para transformar Project em ProjectViewModel
        public static ProjectViewModel ToEntity(Project project)
        {
            return new ProjectViewModel
            {
                Id = project.Id,
                Title = project.Title,

                Status = project.Status,
                UserId = project.UserId,
                OriginDate = project.OriginDate,
                CreatedAt = project.CreatedAt,
                StartedAt = project.StartedAt,
                CompletedAt = project.CompletedAt,
                IsDeleted = project.IsDeleted,
                Description = project.Description,
                ActionIds = project.Actions?.Select(a => a.Id).ToList() ?? new List<int>(),
                Origin = project.Origin,
                OriginNumber = project.OriginNumber,
                ConclusionText = project.ConclusionText
            };
        }
    }
}