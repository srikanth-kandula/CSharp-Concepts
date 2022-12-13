using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class Dynamic
    {
        public Dynamic()
        {
            dynamic a = true; // its type at runtime will by dynamic{bool}
            a = 10; // a will be of type - dynamic{int}

            dynamic s = "someString";
            //s++;//compiler doesn't throw any error but a RuntimeBinderException occurs as ++ is not supported on string.

            //no need of typecasting if the runtime type can be assigned to the defined static type
            int b = 22;
            dynamic c = 20;
            long d = c;
            dynamic e = b;

            //var vs dynamic
            var myVar = 69; dynamic myDynamic = 69;
            //myVar = "new string"; //myVar will be of type int and a string value can't be assigned to it.
            myDynamic = "new string";
            //var temp; //throws error as it is not defined when declare using var
        }
    }
}
