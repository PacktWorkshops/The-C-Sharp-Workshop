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

    public class Order
    {
        public string intent { get; set; }
        public Purchase_Units[] purchase_units { get; set; }
        public Payer payer { get; set; }
    }

    public class Payer
    {
        public string email_address { get; set; }
        public Name name { get; set; }
    }

    public class Name
    {
        public string name { get; set; }
    }

    public class Purchase_Units
    {
        public string reference_id { get; set; }
        public Amount amount { get; set; }
        public Payee payee { get; set; }
    }

    public class Amount
    {
        public string currency_code { get; set; }
        public string value { get; set; }
    }

    public class CreatedOrderResponse
    {
        public string id { get; set; }
        public string intent { get; set; }
        public string status { get; set; }
        public Purchase_Units[] purchase_units { get; set; }
        public Payer payer { get; set; }
        public DateTime create_time { get; set; }
        public Link[] links { get; set; }
    }

    public class Payee
    {
        public string email_address { get; set; }
        public string merchant_id { get; set; }
    }

    public class Link
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string method { get; set; }
    }


}
