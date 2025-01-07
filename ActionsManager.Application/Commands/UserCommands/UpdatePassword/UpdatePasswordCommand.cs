using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace _5W2H.Application.Commands.UserCommands.UpdatePassword
{
    public class UpdatePasswordCommand : IRequest<bool>
    {
        public int UserId { get; set;}
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

    }
}