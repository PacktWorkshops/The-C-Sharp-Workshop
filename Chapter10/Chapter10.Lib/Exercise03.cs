using System;

namespace Chapter10.Lib
{
    public record Order
    {
        public Order (double totalValue, int quantity)
            => (TotalValue, Quantity) = (totalValue, quantity);

        public double TotalValue {get; init;}
        public int Quantity { get; init; }
    }

    public interface IDiscounter 
    {
        Order Apply(Order order);
    }

    public class ShoppingBasket
    {
        private readonly IDiscounter _discounter;

        public ShoppingBasket(IDiscounter discounter, Order order)
        {
            _discounter = discounter;
            Order = order;
        }

        public Order Order {get; private set;}

        private bool _discountApplied;

        public void ApplyDiscount(char code)
        {
            if (_discountApplied)
                return;

            if (code is (>= 'a' and  <='c'))
            {
                Order = _discounter.Apply(Order);
                _discountApplied = true;
            }
        }

    }
}