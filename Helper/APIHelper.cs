using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Helper
{

    public class APIHelper
    {        
        static readonly HttpClient client = new HttpClient();
        
        public APIHelper()
        {
             Console.WriteLine("APIHelper Object successfully created\n");
             client.BaseAddress = new Uri("https://api.github.com");
             client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
        }
        public async Task RequestGitHub(string url)
        {            
            url = "repos/Zanark/Tanban/contributors";
            
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