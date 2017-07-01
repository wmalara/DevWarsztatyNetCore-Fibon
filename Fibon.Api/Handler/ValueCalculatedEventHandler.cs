using Fibon.Api.Repository;
using Fibon.Messages.Events;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fibon.Api.Handler
{
    public class ValueCalculatedEventHandler : IEventHandler<ValueCalculatedEvent>
    {
        private readonly IRepository repository;

        public ValueCalculatedEventHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public Task HandleAsync(ValueCalculatedEvent @event)
        {
            repository.Add(@event.Number, @event.Value);

            return Task.CompletedTask;
        }
    }
}
