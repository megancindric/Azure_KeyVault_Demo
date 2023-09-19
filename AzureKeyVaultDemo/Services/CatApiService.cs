using AzureKeyVaultDemo.Models;
using Newtonsoft.Json;

namespace AzureKeyVaultDemo.Services
{
    public class CatApiService
    {

        public async Task<List<Cat>> GetCatAsync()
        {
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://api.thecatapi.com/v1/images/search?limit=50");
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
