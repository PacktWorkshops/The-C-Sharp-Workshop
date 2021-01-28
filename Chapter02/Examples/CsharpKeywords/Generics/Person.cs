using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02.Examples.CsharpKeywords.Generics
{
    public class Person
    {
        public string Name { get; set; }
        public int Id { get; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
