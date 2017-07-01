using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fibon.Messages.Commands
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<in T>
        where T : ICommand
    {
        Task HandleAsync(T command);
    }

    public class CalculateValueCommand : ICommand
    {
        public CalculateValueCommand(int number)
        {
            Number = number;
        }

        protected CalculateValueCommand()
        {
        }

        public int Number { get; private set; }
    }
}
