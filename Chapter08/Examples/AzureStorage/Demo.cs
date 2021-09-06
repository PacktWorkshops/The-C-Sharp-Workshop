using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Chapter08.Examples.AzureAD
{
    static class Demo
    {
        public static string ClientID = "fa5b9dba-1996-417a-9499-89657a184664";
        public static string ClientSecret = "bk~og~X558Qf.uc6xnT1q5E9rW4_V0qm3.";
        public static string TenantID = "ddd0fd18-f056-4b33-88cc-088c47b81f3e";
        public static string AccessToken { get; set; }

        public static void Run()
        {
            var token = GetAuthorizationToken().Result;
            Console.WriteLine(token.AccessToken);

            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(new Uri("https://csb10032000fe8ae479.blob.core.windows.net/"), new ClientSecretCredential(TenantID, ClientID, ClientSecret));

            //Create a unique name for the container
            string containerName = "quickstartblobs" + Guid.NewGuid().ToString();

            // Create the container and return a container client object
            BlobContainerClient containerClient = blobServiceClient.CreateBlobContainer(containerName);
        }

        public static Task<AuthenticationResult> GetAuthorizationToken()
        {
            ClientCredential credentials = new ClientCredential(ClientID, ClientSecret);
            var context = new AuthenticationContext("https://login.microsoftonline.com/" + TenantID);
            var result = context.AcquireTokenAsync("https://management.azure.com/", credentials);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to obtain the Access token");
            }

            return result;
        }


    }
}
