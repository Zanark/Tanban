using System;
using Helper;
using System.Threading.Tasks;

namespace Tanban
{
    class Program
    {
        static async Task Main(string[] args)
        {            
            
            ConsoleUI console = new ConsoleUI("Zanark");
            await console.ListRepositories();

        }
    }
}
