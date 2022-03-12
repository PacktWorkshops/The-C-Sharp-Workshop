using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter06.Examples.Cqrs
{
    public class CreateProductCommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Manufacturerid { get; set; }
    }
}
