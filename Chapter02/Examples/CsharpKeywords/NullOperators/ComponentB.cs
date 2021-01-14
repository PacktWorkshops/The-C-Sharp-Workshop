using System;

namespace Chapter02.Examples.CsharpKeywords.NullOperators
{
    class ComponentB
    {
        private readonly ComponentA _componentA;

        public ComponentB(ComponentA componentA)
        {
            if (componentA == null)
            {
                throw new ArgumentException(nameof(componentA));
            }
            else
            {
                _componentA = componentA;
            }

            _componentA = componentA ?? throw new ArgumentNullException(nameof(componentA));
        }
    }
}
