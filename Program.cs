using System;
using Helper;
using System.Threading.Tasks;

namespace Tanban
{
    class Program
    {
        static async Task Main(string[] args)
        {            
            //TODO: MAKE AUTH FILE FOR USER
            Console.WriteLine("Enter your Username");
            string username = Console.ReadLine();
            
            ConsoleUI console = new ConsoleUI(username);

            await console.ListRepositories();

        }
    }
}
