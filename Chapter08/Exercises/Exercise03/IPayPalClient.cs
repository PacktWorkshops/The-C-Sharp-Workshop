using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace Chapter08.Exercises.Exercise03
{
    public interface IPayPalClient
    {
        [Post("/v2/checkout/orders")]
        public Task<CreatedOrderResponse> CreateOrder(Order order);

        [Get("/v2/checkout/orders/{id}")]
        public Task<Order> GetOrder(string id);
    }

    public record Order
    {
        public string intent { get; set; }
        public Purchase_Units[] purchase_units { get; set; }
    }

    public record Name
    {
        public string name { get; set; }
    }

    public record Purchase_Units
    {
        public Amount amount { get; set; }
        public Payee payee { get; set; }
    }

    public record Amount
    {
        public string currency_code { get; set; }
        public string value { get; set; }
    }

    public record CreatedOrderResponse
    {
        public string id { get; set; }
    }

    public record Payee
    {
        public string email_address { get; set; }
    }
}
