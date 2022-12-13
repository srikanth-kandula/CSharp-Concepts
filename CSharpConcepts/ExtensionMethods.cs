using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class ExtensionMethods
    {
        public string longString = "This is a very very very looooong string.....";
        public ExtensionMethods()
        {
            //Reduce is an extension method
            string shortenedString = longString.Reduce(3);//Notice that a static method Reduce is used on an instance!!!
            //Note if the instance has same method 'Reduce', it takes priority over the static method.

            Console.WriteLine(shortenedString);
        }        
    }

    public static class StringExtensions //general guideline is to use the original class name + 'Extensions'
    {
        //Extension method must have the below signature
        //public static returnType Name (this TypeBeingExtented someName, typeOfArgument nameOfArgumentIfAny)
        public static string Reduce(this String str, int numberOfWords)
        {
           if(numberOfWords < 0)
           {
                throw new ArgumentOutOfRangeException("number of words must be greater than zero");
           } else
            {
                string[] totalWords = str.Split(' ');
                if(totalWords.Length <= numberOfWords)
                {
                    return str;
                } else
                {
                    return string.Join(" ", totalWords.Take(numberOfWords));
                }
            }
        }
    }
}
