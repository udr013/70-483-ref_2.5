using System;
using System.Collections.Generic;
using System.Text;

namespace Attributes
{
    class MyAttribute : Attribute
    {
        private string myValue;

        public MyAttribute(string value)
        {
            this.myValue = value;
        }

        public string MyValue
        {
            get
            {
                return myValue;
            }
        }

    }
    
}
