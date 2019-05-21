using System;
using System.Collections.Generic;
using System.Text;

namespace Attributes
{
    //Serializable Attribute
    [Serializable, MyAttribute("blabal")]
    public class Person
    {
        public string Name;
        public int Age;

        [NonSerialized]
        //no need to save this
        private int screenPosition;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            this.screenPosition = 0;
        }
    }
}
