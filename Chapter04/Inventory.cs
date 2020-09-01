using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter04
{
    public static class Inventory
    {
        public static IEnumerable<Product> GetSampleProducts() => new Product[]
        {
            new Product() { Name = "widget1", SalePrice = 34.5m, Cost = 22m, QuantityOnHand = 114, Id = 1 },
            new Product() { Name = "widget2", SalePrice = 12.75m, Cost = 9m, QuantityOnHand = 332, Id = 2 },
            new Product() { Name = "widget3", SalePrice = 21.1m, Cost = 15m, QuantityOnHand = 49, Id = 3 },
            new Product() { Name = "widget4", SalePrice = 47.65m, Cost = 39m, QuantityOnHand = 12, Id = 4 },
            new Product() { Name = "widget5", SalePrice = 34.11m, Cost = 15m, QuantityOnHand = 21, Id = 5 },
            new Product() { Name = "widget6", SalePrice = 18.70m, Cost = 19m, QuantityOnHand = 6, Id = 6 },
            new Product() { Name = "widget7", SalePrice = 25m, Cost = 17.66m, QuantityOnHand = 10, Id = 7 }
        };

        public static void ShowProductsInPriceRange(IEnumerable<Product> products, decimal lowPrice, decimal highPrice)
        {
            Console.WriteLine($"Products between {lowPrice:c2} and {highPrice:c2}:");

            var inPriceRange = products
                .Where(p => p.SalePrice > lowPrice && p.SalePrice < highPrice)
                .OrderBy(p => p.SalePrice);

            inPriceRange.ToList().ForEach(p => Console.WriteLine($"{p.Name} at {p.SalePrice:c2}"));
            Console.WriteLine();
        }

        public static IEnumerable<Product> GetRandomProducts(int count)
        {
            var rnd = new Random();

            return Enumerable.Range(1, count).Select(i => buildRandomProduct(i));

            Product buildRandomProduct(int index)
            {
                var price = rnd.Next(50, 500) / 10m;
                var multiplier = rnd.Next(50, 115) / 100m;
                var cost = price * multiplier;

                return new Product()
                {
                    Name = $"product{index}",
                    SalePrice = price,
                    Cost = cost,
                    QuantityOnHand = rnd.Next(10, 100)
                };
            }
        }

        public static IEnumerable<Customer> GetSampleCustomers() => new Customer[]
        {
            new Customer() { Name = "customer1", Id = 1 },
            new Customer() { Name = "customer2", Id = 2 },
            new Customer() { Name = "customer3", Id = 3 }
        };

        public static IEnumerable<Order> GetSampleOrders() => Enumerable.Range(1, 20).Select(i => new Order()
        {
            Id = i,
            CustomerId = (i % 3) + 1,            
            Products = GetRandomOrderProducts(2, 5)
        });

        public static IEnumerable<OrderProduct> GetRandomOrderProducts(int minCount, int maxCount)
        {
            Random rnd = new Random();
            int count = rnd.Next(minCount, maxCount);

            var allProducts = GetSampleProducts();

            return Enumerable.Range(1, count).Select(i =>
            {
                int productId = rnd.Next(allProducts.Min(p => p.Id), allProducts.Max(p => p.Id));
                return new OrderProduct()
                {
                    ProductId = productId,
                    Quantity = rnd.Next(1, 5)
                };
            });
        }

        public static void ShowProductsWhere(IEnumerable<Product> products, Func<Product, bool> predicate)
        {
            Console.WriteLine("ShowProductsWhere:");

            foreach (var p in products.Where(predicate)) Console.WriteLine($"{p.Name} at {p.SalePrice:c2}");

            Console.WriteLine();
        }

        public static void ShowOrderedProductsWhere<T>(IEnumerable<Product> products, Func<Product, bool> predicate, Func<Product, T> orderBy)
        {
            Console.WriteLine("ShowOrderedProductsWhere:");

            foreach (var p in products.Where(predicate).OrderBy(orderBy)) Console.WriteLine($"{p.Name} at {p.SalePrice:c2}");

            Console.WriteLine();
        }

        public static void ShowInventoryValue(IEnumerable<Product> products)
        {
            var inventoryValue = products.Sum(p => p.QuantityOnHand * p.Cost);
            Console.WriteLine($"The total inventory value is {inventoryValue:c2}");
        }

        public static void ShowHighAndLowMargins(IEnumerable<Product> products)
        {
            Console.WriteLine("Highest margin products:");
            var topMargins = products.OrderByDescending(p => p.GetMargin()).Take(3);
            ListProducts(topMargins);

            Console.WriteLine();

            Console.WriteLine("Lowest margin products:");
            var bottomMargins = products.OrderBy(p => p.GetMargin()).Take(3);
            ListProducts(bottomMargins);

            Console.WriteLine();

            void ListProducts(IEnumerable<Product> products)
            {
                int rank = 0;
                foreach (var p in products)
                {
                    rank++;
                    Console.WriteLine($"#{rank} product: {p.Name} at {p.GetMargin():c2}");
                }
            }
        }

        public static void OrderByHighestAndLowest(IEnumerable<Product> products)
        {
            var byPrice = products.OrderBy(p => p.SalePrice);

            var lowestPrice = byPrice.First();
            Console.WriteLine($"The lowest price item is {lowestPrice.Name} at {lowestPrice.SalePrice:c2}");

            var highestPrice = byPrice.Last();
            Console.WriteLine($"The highest price item is {highestPrice.Name} at {highestPrice.SalePrice:c2}");

            var byMargin = products.OrderBy(p => p.GetMargin());

            var lowestMargin = byMargin.First();
            Console.WriteLine($"The lowest profit margin item is {lowestMargin.Name} at {lowestMargin.GetMargin():c2}");

            var highestMargin = byMargin.Last();
            Console.WriteLine($"The highest profit margin item is {highestMargin.Name} at {highestMargin.GetMargin():c2}");

            Console.WriteLine();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Cost { get; set; }
        public int QuantityOnHand { get; set; }

        public decimal GetMargin() => SalePrice - Cost;
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<OrderProduct> Products { get; set; }
    }

    public class OrderProduct
    {        
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
