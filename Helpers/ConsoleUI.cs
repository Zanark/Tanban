using DataClass;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Helper
{
    class ConsoleUI
    {
        
        private string user;
        public ConsoleUI(string user)
        {
            this.user = user;            
        }

        public async Task ListRepositories()
        {
            var url = "/users/" + this.user + "/repos";
            
            // Console.WriteLine("Calling APIHelper.request_GitHub(url) ");
            APIHelper apihelper = new APIHelper();
            string response = await apihelper.request_GitHub(url);

            // Console.WriteLine("Calling DeserializeJSON.ParseRepositoryJSONResponse(response) ");
            var repositories = DeserializeJSON.ParseRepositoryJSONResponse(response);
            
            Console.WriteLine("Repositories under user: "+ user);
            var count = repositories.Count;
            Console.WriteLine(count);
            repositories.ForEach(Console.WriteLine);

        }
        public void ListProjects(Repository repository)
        {

        }

        public void DisplayProject(Project project)
        {

        }

    }
}