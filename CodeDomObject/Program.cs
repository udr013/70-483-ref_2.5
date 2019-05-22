using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace CodeDomObject
{
    class Program
    {
        //Code Document Object Model
        static void Main(string[] args)
        {
            CodeCompileUnit codeCompileUnit = new CodeCompileUnit();

            //create a namespace to hold the types we are going to create
            CodeNamespace personnalNamespace = new CodeNamespace("Personnel");
            //import the system namespace
            personnalNamespace.Imports.Add(new CodeNamespaceImport("System"));
            
            //create a Person class
            CodeTypeDeclaration personClass = new CodeTypeDeclaration("Person");
            personClass.IsClass = true;
            personClass.TypeAttributes = System.Reflection.TypeAttributes.Public;
            
            //Create a field to hold the name of person
            CodeMemberField nameField = new CodeMemberField("String", "name");
            nameField.Attributes = MemberAttributes.Private;
            personClass.Members.Add(nameField);

            //Add the person class to personnelNamespace and addit to compileunit
            personnalNamespace.Types.Add(personClass);
            codeCompileUnit.Namespaces.Add(personnalNamespace);

            //Create a provider to parse the document and  a space to send output
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            StringWriter s = new StringWriter();
            //Set options for parsing, we use the defaults...
            CodeGeneratorOptions options = new CodeGeneratorOptions();

            //Generate the C# source from the codeDOM
            provider.GenerateCodeFromCompileUnit(codeCompileUnit, s, options);
            //Close output stream
            s.Close();

            Console.WriteLine(s.ToString());
         
        }
    }
}
