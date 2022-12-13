using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.LINQ
{
    class DemoLinqQueries
    {
        public DemoLinqQueries()
        {
            Console.WriteLine(findUniqueCharsInString("aabBcDestrinnGg"));
            filterArrayElements();
        }

        private string findUniqueCharsInString(string input)
        {
            string result = "";

            char[] characters = input.ToCharArray(); //we need a list of items to apply LINQ queries
            var arr = characters.Distinct().ToArray(); //use Distinct LINQ query, convert to array and then to string
            result = new string(arr);

            return result;
        }

        private void filterArrayElements()
        {
            string[] names = { "Bill", "Steve", "James", "Mohan" };

            //find all names with letter a in them
            //the query is created here. This will not be executed here.
            var filteredNamesQuery = names
                        .Where(name => name.Contains('a'));
            //.Select(name => name); // not required, select will be useful to select a particular field within object, if needed.

            Console.WriteLine(filteredNamesQuery); // will log a LINQ query, not the result of executing the query
            //https://www.tutorialsteacher.com/linq/what-is-linq

            //LINQ query is executed here!!!
            foreach (string name in filteredNamesQuery)
                Console.WriteLine($"name: {name}");
        }
    }
}
