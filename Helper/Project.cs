using System;
using Newtonsoft.Json;

namespace Helper
{
    class Project
    {
        public string project_id { get; set; }
        public short owner_url { get; set; }

        public override string ToString()
        {
            return "stuff";
        }
    }
}