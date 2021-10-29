using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;

namespace Assignment2
{
    public class NetworkingManager
    {
        private string url = "https://openlibrary.org/search.json?title=";
        private string authorUrl = "https://openlibrary.org/search.json?author=";

        HttpClient client = new HttpClient();

        public NetworkingManager()
        {

        }

        public async Task<List<Book>> getBooks(string title)
        {
            string completeURL = url + title;
            var response = await client.GetAsync(completeURL);
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<Book>();
            }
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var dictonary = JsonConvert.DeserializeObject<Dictionary<String, object>>(jsonString);
                var array = dictonary.ElementAt(3).Value;
                var finalList = JsonConvert.DeserializeObject<List<Book>>(array.ToString());
                return finalList;

            }
        }
        public async Task<List<Book>> getBooksByAuthor(string author)
        {
            string completeURL = authorUrl + author;
            var response = await client.GetAsync(completeURL);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<Book>();
            }
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var dictonary = JsonConvert.DeserializeObject<Dictionary<String, object>>(jsonString);
                var array = dictonary.ElementAt(3).Value;
                var finalList = JsonConvert.DeserializeObject<List<Book>>(array.ToString());
                return finalList;

            }
        }
    }
}
