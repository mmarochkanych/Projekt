using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_info.Models;

namespace Student_info.Services
{
    public class MockDataStore 
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                //new Item  { Id = Guid.NewGuid().ToString(), FName = "Mariia", LName = "Marochkanych", Index="w60105" ,  Gender = "Kobieta", ImgUrl = "https://1.bp.blogspot.com/-Ky93eGCqI-c/XtOunmvxuwI/AAAAAAAABzU/CHSOhId2Hs4jOCzapD7mR5cVTrDkxURZACK4BGAsYHg/s320/me.jpg"},
               // new Item  { Id = Guid.NewGuid().ToString(), FName = "Anastasia", LName = "Kushyk", Index="w60152" ,  Gender = "Kobieta", ImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSJQayz7qPKk91rCaYsBr-SdW90UuIlvbebDbWAIo0zW7cjyiI3&usqp=CAU"},
               
                
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}