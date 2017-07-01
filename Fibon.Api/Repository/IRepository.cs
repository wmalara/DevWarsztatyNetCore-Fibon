using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fibon.Api.Repository
{
    public interface IRepository
    {
        void Add(int number, int result);

        int? Get(int number);
    }

    public class InMemoryRepository : IRepository
    {
        public readonly Dictionary<int, int> storage = new Dictionary<int, int>();

        public void Add(int number, int result)
        {
            storage[number] = result;
        }

        public int? Get(int number)
        {
            return storage.TryGetValue(number, out int value) 
                ? value 
                : default(int?);
        }
    }
}
