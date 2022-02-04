using System.Collections.Generic;
using System.Threading.Tasks;
using Chapter08.Exercises.Exercise02.Models;
using RestSharp;
// Auto - generated
#pragma warning disable CS0108, CS0114

namespace Chapter08.Activities.Activity02
{
    public class CountriesClient
    {
        private readonly RestClient _client;

        public CountriesClient()
        {
            _client = new RestClient("https://restcountries.com/v3/");
        }

        public Task<IEnumerable<Country>> Get() => GetCountries("/all");

        public Task<IEnumerable<Country>> GetByLanguage(string language) => GetCountries($"/lang/{language}");

        public Task<IEnumerable<Country>> GetByCapital(string capital) => GetCountries($"capital/{capital}");

        private async Task<IEnumerable<Country>> GetCountries(string endpoint)
        {
            var request = new RestRequest(endpoint);
            var result = await _client.GetAsync<IEnumerable<Country>>(request);

            return result;
        }
    }

    public class CommonNames
    {
        public NativeName aym { get; set; }
        public NativeName que { get; set; }
        public NativeName spa { get; set; }
    }

    public class Name
    {
        public string common { get; set; }
        public string official { get; set; }
        public CommonNames nativeName { get; set; }
    }

    public class PEN
    {
        public string name { get; set; }
        public string symbol { get; set; }
    }

    public class Currencies
    {
        public PEN PEN { get; set; }
    }

    public class Idd
    {
        public string root { get; set; }
        public List<string> suffixes { get; set; }
    }

    public class Languages
    {
        public string aym { get; set; }
        public string que { get; set; }
        public string spa { get; set; }
    }

    public class Fra : NativeName
    {
        public string official { get; set; }
        public string common { get; set; }
        public string f { get; set; }
        public string m { get; set; }
    }

    public class NativeName
    {
        public string official { get; set; }
        public string common { get; set; }
    }

    public class Translations
    {
        public NativeName ces { get; set; }
        public NativeName deu { get; set; }
        public NativeName est { get; set; }
        public NativeName fin { get; set; }
        public Fra fra { get; set; }
        public NativeName hrv { get; set; }
        public NativeName hun { get; set; }
        public NativeName ita { get; set; }
        public NativeName jpn { get; set; }
        public NativeName kor { get; set; }
        public NativeName nld { get; set; }
        public NativeName per { get; set; }
        public NativeName pol { get; set; }
        public NativeName por { get; set; }
        public NativeName rus { get; set; }
        public NativeName slk { get; set; }
        public NativeName spa { get; set; }
        public NativeName swe { get; set; }
        public NativeName urd { get; set; }
        public NativeName zho { get; set; }
    }

    public class Eng
    {
        public string f { get; set; }
        public string m { get; set; }
    }

    public class Demonyms
    {
        public Eng eng { get; set; }
        public Fra fra { get; set; }
    }

    public class Country
    {
        public Name name { get; set; }
        public List<string> tld { get; set; }
        public string cca2 { get; set; }
        public string ccn3 { get; set; }
        public string cca3 { get; set; }
        public string cioc { get; set; }
        public bool independent { get; set; }
        public string status { get; set; }
        public bool unMember { get; set; }
        public Currencies currencies { get; set; }
        public Idd idd { get; set; }
        public List<string> capital { get; set; }
        public List<string> altSpellings { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public Languages languages { get; set; }
        public Translations translations { get; set; }
        public List<double> latlng { get; set; }
        public bool landlocked { get; set; }
        public List<string> borders { get; set; }
        public double area { get; set; }
        public string flag { get; set; }
        public List<string> flags { get; set; }
        public Demonyms demonyms { get; set; }
    }
}
