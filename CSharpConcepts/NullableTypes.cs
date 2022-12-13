using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class NullableTypes
    {
        public NullableTypes()
        {
            //bool isEnabled = null; // as bool is value type, a null value can't be assigned to it.
            Nullable<bool> isEnabled1 = null; //Nullable<> can be used to assign a null value to a value type.
            bool? isEnabled2 = null; //This is a shorthand notation of above line

            DateTime? date1 = null;
            DateTime date2 = date1.GetValueOrDefault();

            //commonly used methods on nullable types
            Console.WriteLine(date1.GetValueOrDefault());
            Console.WriteLine(date1.HasValue);
            Console.WriteLine(date1.Value); // will throw exception if date1 is null
        }
    }
}
