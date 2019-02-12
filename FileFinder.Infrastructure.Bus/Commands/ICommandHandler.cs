using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileFinder.Infrastructure.Bus.Commands
{
    public interface ICommandHandler<T> : IRequestHandler<T>
        where T : ICommand
    {
    }
}
