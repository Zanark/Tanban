using System;

namespace Helper
{
    class ConsoleUI
    {
        private string seperator = "\n============================";
        
        public ConsoleUI(Project project)
        {
            Console.WriteLine(project.name + seperator);
            Console.WriteLine(project.body + seperator);
        }
    }
}