#define TERSE
#define VERBOSE
#define MARK

using System;
using System.Diagnostics;

namespace Attributes
{

    class Program
    {
        //conditional Attribute
        [Conditional("VERBOSE"), Conditional("TERSE")]
        static void reportHeader()
        {
            Console.WriteLine("This is the header for the report");
        }

        [Conditional("VERBOSE")]
        static void verboseReport()
        {
            Console.WriteLine("This is the output for the verbose report");
        }

        [Conditional("TERSE")]
        static void terseReport()
        {
            Console.WriteLine("This is the output for the terse report");
        }


        [Conditional("MARK")]
        static void markReport()
        {
            Console.WriteLine("This is the output for the mark report");
        }
        static void Main(string[] args)
        {

            if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute)))
            {
                Console.WriteLine("Person is serializable");
            }

            reportHeader();
            terseReport();
            verboseReport();
            markReport();


            Attribute a = Attribute.GetCustomAttribute(typeof(Person), typeof(MyAttribute));
            MyAttribute mine = (MyAttribute)a;
            Console.WriteLine("MyAttribute : {0}", mine.MyValue);
            Console.ReadKey();
        }
    }
}
