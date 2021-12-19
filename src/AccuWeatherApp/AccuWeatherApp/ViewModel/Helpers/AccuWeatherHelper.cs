using AccuWeatherApp.Model;
using AccuWeatherApp.Model.City;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AccuWeatherApp.ViewModel.Helpers
{
    internal class AccuWeatherHelper
    {
        public const string BaseUrl = "http://dataservice.accuweather.com/";
        public const string AutoCompleteEndpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CurrentConditionsEndpoint = "currentconditions/v1/{0}?apikey={1}";
        public const string ApiKey = "N3F5BGA6acDcyVRhWvDCR1FJsVAIyDNT";

        public static async Task<List<City>> GetCities(string query)
        {
            string url = BaseUrl + string.Format(AutoCompleteEndpoint, ApiKey, query);

            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<City>>(json) ?? new List<City>();
        }

        public static async Task<CurrentCondition> GetCurrentConditionAsync(string cityKey)
        {
            string url = BaseUrl + string.Format(CurrentConditionsEndpoint, cityKey, ApiKey);

            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CurrentCondition>>(json)?.FirstOrDefault() ?? new CurrentCondition();
        }
    }
}
