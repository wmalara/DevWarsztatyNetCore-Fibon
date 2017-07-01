using Fibon.Api.Repository;
using Fibon.Messages.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fibon.Api.Controllers
{
    [Route("[controller]")]
    public class FibonacciController : Controller
    {
        private readonly IBusClient busClient;
        private readonly IRepository repository;

        public FibonacciController(IBusClient busClient, IRepository repository)
        {
            this.busClient = busClient;
            this.repository = repository;
        }

        [HttpGet("{number}")]
        public IActionResult Get(int number)
        {
            var calculatedValue = repository.Get(number);
            if(calculatedValue.HasValue)
            {
                return Content(calculatedValue.ToString());
            }

            return NotFound();
        }

        [HttpPost("{number}")]
        public async Task<IActionResult> Post(int number)
        {
            var calculatedValue = repository.Get(number);
            if (!calculatedValue.HasValue)
            {
                await busClient.PublishAsync(new CalculateValueCommand(number));
            }

            return Accepted($"fibonacci/{number}", null);
        }
    }
}
