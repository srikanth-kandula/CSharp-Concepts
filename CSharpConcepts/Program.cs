using CSharpConcepts.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class Program
    {
        static void Main(string[] args)
        {
            //DemoGenerics();
            //var demoDelegates = new Delegates();
            //var demoExtensions = new ExtensionMethods();
            //var demoLinq = new Linq();
            //var demoNullableTypes = new NullableTypes();
            //var demoDynamic = new Dynamic();
            //var demoExceptionHandling = new ExceptionHandling();
            var demoStringManipulationsUsingLINQ = new DemoLinqQueries();

            int[] intArray = new int[4];

            Console.ReadLine();
        }

        static void DemoGenerics()
        {
            Generics<string> genericsObj = new Generics<string>();

            genericsObj.Add("someStringValue");
            genericsObj.Remove();

            Generics<int> intergersObj = new Generics<int>();
            intergersObj.Add(1);
            intergersObj.Remove();
        }
    }
}
