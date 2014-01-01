using System;
using System.Collections.Generic;
using System.Text;

namespace AhnAndroidApp_Second
{
    internal enum Gender
    {
        Male,
        Female
    }

    internal class Person
    {
        public String Name { get; set; }
        public Int32 Age { get; set; }
        public Gender Gender { get; set; }
        public Int32 ImageId { get; set; }
    }
}
