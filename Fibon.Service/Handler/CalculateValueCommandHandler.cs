using Fibon.Messages.Commands;
using Fibon.Messages.Events;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fibon.Service.Handler
{
    public class CalculateValueCommandHandler : ICommandHandler<CalculateValueCommand>
    {
        private readonly IBusClient busClient;

        public CalculateValueCommandHandler(IBusClient busClient)
        {
            this.busClient = busClient;
        }

        public async Task HandleAsync(CalculateValueCommand command)
        {
            var result = Fib(command.Number);

            await busClient.PublishAsync(new ValueCalculatedEvent(command.Number, result));
        }

        private static int Fib(int n)
        {
            if (n == 0 || n == 1)
                return n;

            return Fib(n - 2) + Fib(n - 1);
        }
    }
}
