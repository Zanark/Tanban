using System;
using Helper;
using System.Threading.Tasks;

namespace Tanban
{
    class Program
    {
        static async Task Main(string[] args)
        {

            APIHelper apihelper = new APIHelper();
            await apihelper.request_GitHub("placeholder");


        }
    }
}
