using System;

namespace DataClass
{
    class Project
    {
        public string id { get; set; }
        
        public string name { get; set; }

        public string body { get; set; }

        public override string ToString()
        {
            return $"{name}\n";
        }

    }
}