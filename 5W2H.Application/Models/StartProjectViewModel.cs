using _5W2H.Core.Entities;

namespace _5W2H.Application.Models;

public class StartProjectViewModel
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public Project Project { get; set; } 
}