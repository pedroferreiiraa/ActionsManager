    using _5W2H.Application.Models;
    using _5W2H.Core.Entities;
    using MediatR;


    namespace _5W2H.Application.Commands.ProjectsCommands.InsertProjectAction;


    public class InsertProjectActionCommand : IRequest<ResultViewModel<Project>>
    { 
        public int ProjectId { get; set; }
        public int ActionId { get; set; } 


    }
