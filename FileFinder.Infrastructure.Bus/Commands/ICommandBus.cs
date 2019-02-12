using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileFinder.Infrastructure.Bus.Commands
{
    public interface ICommandBus
    {
        Task Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
