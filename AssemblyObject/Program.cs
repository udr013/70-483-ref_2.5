using System;
using System.Reflection;

namespace AssemblyObject
{
    class Program
    { 
        class MyModule
    {
            int bla = 7;
    }

        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Console.WriteLine("Full name: {0}", assembly.FullName);
            AssemblyName name = assembly.GetName();
            Console.WriteLine("Major Version: {0}", name.Version.Major);
            Console.WriteLine("Minor Version: {0}", name.Version.Minor);
            Console.WriteLine("In global assembly cache: {0}", assembly.GlobalAssemblyCache);
            foreach (Module assemblyModule in assembly.Modules)
            {
                Console.WriteLine("module: {0}", assemblyModule.Name);
                foreach (Type moduleType in assemblyModule.GetTypes())
                {
                    Console.WriteLine("    modelType:{0}", moduleType.Name);
                    foreach (MemberInfo memberinfo in moduleType.GetMembers())
                    {
                        Console.WriteLine("       memberinfo {0}", memberinfo.Name);
                        
                    }
                }
            }
        }
    }
}
