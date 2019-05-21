using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Types
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Type type;

            IRecord record = new Lp();
            type = record.GetType();
            Console.WriteLine("type: {0}: ", type);

            Console.WriteLine("----------------");
            //get information about type
            foreach(MemberInfo member in type.GetMembers())
            {              
                Console.WriteLine(member.ToString());
            }

            Console.WriteLine("----------------");
            //using reflection
            MethodInfo setMethod = type.GetMethod("set_Title");
            setMethod.Invoke(record, new object[] { "Check your head" });

            Console.WriteLine(record.Title);

            Console.WriteLine("----------------");

            Assembly thisAssembly = Assembly.GetExecutingAssembly();

            List<Type> recordTypes = new List<Type>();

            //find all classes implementing IRecord
            foreach (Type assemblyType in thisAssembly.GetTypes())
            {
                if (assemblyType.IsInterface)
                {
                    continue;
                }
                if (typeof(IRecord).IsAssignableFrom(assemblyType))
                {
                    recordTypes.Add(assemblyType);
                    Console.WriteLine(assemblyType);
                }
            }
           

            //same using LINQ
            var accountTypes2 = from assemblyType in thisAssembly.GetTypes()
                                where typeof(IRecord).IsAssignableFrom(type)
                                && !type.IsInterface
                                select type;
        }
    }
}
