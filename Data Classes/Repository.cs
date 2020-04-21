using System;

namespace DataClass
{
    class Repository
    {
        public string id { get; set; }
        
        public string full_name { get; set; }

        public bool private_ { get; set; }

        public bool has_projects { get; set; }

        public override string ToString()
        {
            return $"{full_name}\n";
        }

    }

}