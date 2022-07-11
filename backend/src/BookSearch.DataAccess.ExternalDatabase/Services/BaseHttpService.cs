using Newtonsoft.Json;

namespace BookSearch.DataAccess.ExternalDatabase.Services
{
    public abstract class BaseHttpService
    {
        protected readonly HttpClient HttpClient;

        protected BaseHttpService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        protected static async Task<T> ConvertHttpResponseTo<T>(HttpResponseMessage response)
        {
            var modelJson = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<T>(modelJson);
            return model!;
        }
    }
}
