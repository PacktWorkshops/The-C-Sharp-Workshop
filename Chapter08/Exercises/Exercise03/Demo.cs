using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Refit;
using RestSharp;
using ParameterType = RestSharp.ParameterType;

namespace Chapter08.Exercises.Exercise03
{
    public class Demo
    {
        public static string PayPalClientId { get; } = Environment.GetEnvironmentVariable("PayPalClientId", EnvironmentVariableTarget.User);
        public static string PayPalSecret { get; } = Environment.GetEnvironmentVariable("PayPalSecret", EnvironmentVariableTarget.User);
        
        private const string baseAddress = "https://api.sandbox.paypal.com/";
        private static readonly RestClient RestClient = new RestClient(baseAddress);

        public static void Run()
        {
            var authHandler = new AuthHeaderHandler {InnerHandler = new HttpClientHandler() };
            var payPalClient = RestService.For<IPayPalClient>(new HttpClient(authHandler)
                {
                    BaseAddress = new Uri(baseAddress)
                });

            var order = new Order
            {
                intent = "CAPTURE",
                purchase_units = new[]
                {
                    new Purchase_Units
                    {
                        amount = new Amount
                        {
                            currency_code = "EUR", value = "100.00"
                        }
                    }
                }
            };
            var createOrderResponse = payPalClient.CreateOrder(order).Result;
            var payment = payPalClient.GetOrder(createOrderResponse.id).Result;
            var pay = payment.purchase_units.First();
            Console.WriteLine($"{pay.payee.email_address} - " +
                              $"{pay.amount.value}" +
                              $"{pay.amount.currency_code}");
        }

        private class Response
        {
            public string access_token { get; set; }
        }

        public class AuthHeaderHandler : DelegatingHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var accessToken = await GetAccessToken(CreateBasicAuthToken());
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            }

            private static async Task<string> GetAccessToken(string authToken)
            {
                var request = new RestRequest("v1/oauth2/token");
                request.AddHeader("Authorization", authToken);
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials", ParameterType.RequestBody);

                var response = await RestClient.ExecuteAsync<Response>(request, Method.POST);

                return response.Data.access_token;
            }

            private static string CreateBasicAuthToken()
            {
                var credentials = Encoding.GetEncoding("ISO-8859-1").GetBytes(PayPalClientId + ":" + PayPalSecret);
                var authHeader = Convert.ToBase64String(credentials);

                return "Basic " + authHeader;
            }
        }
    }
}
