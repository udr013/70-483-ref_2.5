using System;

namespace PropertyInfo
{

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Person);

            foreach (var prop in type.GetProperties())
            {
                Console.WriteLine("PropertyName: {0} and Type: {1} and Declaring : {2}", prop.Name, prop.PropertyType, prop.DeclaringType);
                if (prop.CanRead)
                {
                    Console.WriteLine("Can read : {0}", prop.GetGetMethod());
                }
                if (prop.CanWrite)
                {
                    Console.WriteLine("Can write : {0}", prop.GetSetMethod());
                }
            }
        }
    }
}
