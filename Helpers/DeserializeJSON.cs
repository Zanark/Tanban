using DataClass;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Helper
{
    class DeserializeJSON
    {
        //private string JSONInput;

        public DeserializeJSON(string json)
        {
            //Constructor
        }

        public static List<Repository> ParseRepositoryJSONResponse(string json)
        {
            var repositories = JsonConvert.DeserializeObject<List<Repository>>(json);
            return repositories;
        }

        public static List<Project> ParseProjectJSONResponse(string json)
        {
            var projects = JsonConvert.DeserializeObject<List<Project>>(json);
            return projects;
        }
    }
}