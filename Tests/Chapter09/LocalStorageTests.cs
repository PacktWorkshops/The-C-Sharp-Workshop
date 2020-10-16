using Chapter09.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Tests.Chapter09
{
    [TestClass]
    public class LocalStorageTests
    {
        [TestMethod]
        public void LocalStorageCreate()
        {
            var ls = new LocalStorage();
            var key = ls.CreateItemAsync(new SampleItem() { FirstName = "whatever", LastName = "nobody" }).Result;

            var item = ls.GetItemAsync<SampleItem>(key).Result;
            Assert.IsTrue(item.FirstName.Equals("whatever") && item.LastName.Equals("nobody"));
        }

        [TestMethod]
        public void LocalStorageListItems()
        {
            var ls = new LocalStorage();
            ls.Clear<SampleItem>();

            const int itemCount = 100;

            // create 100 dummy items
            for (int i = 0; i < itemCount; i++)
            {
                ls.CreateItemAsync(new SampleItem() { FirstName = $"someone{i}", LastName = "anyone" }).Wait();
            }

            // now query all these items, iterating over all the page
            Dictionary<string, SampleItem> results = new Dictionary<string, SampleItem>();
            int page = 0;
            do
            {
                var items = ls.QueryItemsAsync<SampleItem>(page).Result;
                foreach (var item in items) results.Add(item.Key, item.Value);
                if (!items.Any()) break;
                page++;
            } while (true);

            // the number of results should equal what we started with
            Assert.IsTrue(results.Count == itemCount);
        }
    }

    internal class SampleItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
