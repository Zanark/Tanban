using DataClass;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Helper
{
    class ConsoleUI
    {
        
        protected string User;
        
        public APIHelper apihelper = new APIHelper();
        
        public ConsoleUI(string user)
        {
            this.User = user;
        }

        public async Task ListRepositories()
        {
            var url = "/users/" + this.User + "/repos" + "?sort=updated";
            
            // Console.WriteLine("Calling APIHelper.request_GitHub(url) ");
            string response = await apihelper.request_GitHub(url);

            // Console.WriteLine("Calling DeserializeJSON.ParseRepositoryJSONResponse(response) ");
            var repositories = DeserializeJSON.ParseRepositoryJSONResponse(response);
            
            Console.WriteLine("\n\nRepositories under user: "+ User + "\n-------");
            // var count = repositories.Count;
            // Console.WriteLine(count);
            repositories.ForEach(Console.WriteLine);

            Console.WriteLine("Choose a repository");
            string repository_name = Console.ReadLine();
            repository_name = this.User + "/" + repository_name;
            
            var repository = repositories.SingleOrDefault(repo => repo.full_name == repository_name);

            Console.WriteLine("\n\nChosen Repository:\t" + repository.ToString());

            await ListProjects(repository);

        }
        public async Task ListProjects(Repository repository)
        {
            var url = "/repos/" + repository.full_name + "/projects";

            // Console.WriteLine("Calling APIHelper.request_GitHub(url) ");
            string response = await apihelper.request_GitHub(url);

            // Console.WriteLine("Calling DeserializeJSON.ParseRepositoryJSONResponse(response) ");
            var projects = DeserializeJSON.ParseProjectJSONResponse(response);
            
            Console.WriteLine("\nProjects under repo: "+ repository.full_name + "\n-------");
            // var count = repositories.Count;
            // Console.WriteLine(count);
            projects.ForEach(Console.WriteLine);

            Console.WriteLine("Choose a project");
            string project_name = Console.ReadLine();

            var project = projects.SingleOrDefault(p => p.name == project_name);

            Console.WriteLine("\n\nChosen Project:\t" + repository.ToString());

            await DisplayProject(project);

        }

        public async Task DisplayProject(Project project)
        {
            var url = "/projects/" + project.id + "/columns";
            
            // Console.WriteLine("Calling APIHelper.request_GitHub(url) ");
            string response = await apihelper.request_GitHub(url);

            Console.WriteLine(response);


        }

    }
}