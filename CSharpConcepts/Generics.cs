using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class Generics<T>
    {
        private T _value;
        public void Add(T value)
        {
            _value = value;
            Console.WriteLine($"{value} is added");
        }

        public T Remove()
        {
            Console.WriteLine($@"\n{_value} is removed");
            return _value;
        }
    }

}
