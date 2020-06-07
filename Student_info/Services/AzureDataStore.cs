using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Student_info.Models;

namespace Student_info.Services
{
    public class AzureDataStore : IDataStore<Item>
    {
        HttpClient client;
        IEnumerable<Item> items;

        public AzureDataStore()
        {
            client = new HttpClient(GetInsecureHandler());
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");

            items = new List<Item>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;
        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"api/Item");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Item>>(json));
            }

            return items;
        }

        public async Task<Item> GetItemAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/Item/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Item>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Item item)
        {
           
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/Item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
                return response.IsSuccessStatusCode;
            return false;
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            //  var buffer = Encoding.UTF8.GetBytes(serializedItem);
            //  var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync($"api/Item/{item.Id}", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/item/{id}");

            return response.IsSuccessStatusCode;
        }
        // This method must be in a class in a platform project, even if
        // the HttpClient object is constructed in a shared project.
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain,
           errors) =>
            {
                return true;
            };
            return handler;
        }

    }
}
