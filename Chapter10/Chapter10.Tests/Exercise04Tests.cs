using NUnit.Framework;
using Chapter10.Lib;

namespace Chapter10.Tests;

internal class MockDiscounter : IDiscounter
{
    public int ApplyCalls {get; private set;}
    public Order NewOrder {get; private set;}
    public Order Apply(Order order)
    {
        ApplyCalls ++;
        NewOrder = order with {};
        return NewOrder;
    }
}

[TestFixture]
public class ShoppingBasketTests
{
    [TestCase('a', 1)]
    [TestCase('b', 1)]
    [TestCase('c', 1)]
    [TestCase('d', 0)]
    public void ApplyDiscount_TestCase_CallsApply(char code, int expectedCalls)
    {
        // ARRANGE
        MockDiscounter discounter = new();
        var order = new Order(19.99, 2);
        var basket = new ShoppingBasket(discounter, order);

        // ACT 
        basket.ApplyDiscount(code);
        basket.ApplyDiscount(code);

        // ASSERT
        Assert.That(discounter.ApplyCalls, Is.EqualTo(expectedCalls));
    } 
}
