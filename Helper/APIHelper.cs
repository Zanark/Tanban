using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using DotNetEnv;

namespace Helper
{

    public class APIHelper
    {        
        static readonly HttpClient client = new HttpClient();
        
        public APIHelper()
        {
            client.BaseAddress = new Uri("https://api.github.com");
            client.DefaultRequestHeaders.Add("User-Agent", "Tanban");
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github.inertia-preview+json"));

            DotNetEnv.Env.Load();
            var authToken = Encoding.ASCII.GetBytes(DotNetEnv.Env.GetString("GITHUB_TOKEN", "Variable not found"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(authToken));
        }

        private async Task list_headers(string url)
        {
            var result = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, url));

            Console.WriteLine(result + "\n\n");
        }
        public async Task request_GitHub(string url)
        {            
            url = "/repos/Zanark/HackCal/projects";            
          
            try	
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var resp = await response.Content.ReadAsStringAsync();
                Console.WriteLine(resp);
            }  
            catch(HttpRequestException e)
            {
                Console.WriteLine("Inside catch");
                HttpResponseMessage response = await client.GetAsync(url);
                Console.WriteLine("\nException Caught!");	
                Console.WriteLine("Message :{0} ",e.Message);
            }
        }
        


    }

}