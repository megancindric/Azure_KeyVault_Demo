using AzureKeyVaultDemo.Models;
using Newtonsoft.Json;

namespace AzureKeyVaultDemo.Services
{
    public class CatApiService
    {

        public async Task<List<Cat>> GetCatAsync(string apiKey)
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUrl = $"https://api.thecatapi.com/v1/images/search?limit=50&api_key={apiKey}";
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    List<Cat> cats = JsonConvert.DeserializeObject<List<Cat>>(jsonResponse);
                    return cats;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
