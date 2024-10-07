using _5W2H.Application.Models;
using _5W2H.Core;
using MediatR;

namespace _5W2H.Application.ProjectCommands.InsertProject;

public class InsertProjectCommand : IRequest<ResultViewModel<int>>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string What { get;  set; }
    public string Why { get;  set; }
    public DateTime When { get;  set; }
    public string Where { get; set; }
    public string Who { get; set; }
    public string How { get; set; }
    public decimal HowMuch { get;  set; }
    
    public Project ToEntity() 
        => new(Title, What, Why, When, Where, Who, How, HowMuch);
}