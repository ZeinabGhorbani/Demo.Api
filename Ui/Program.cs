using Api.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;

namespace Ui
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("press any key");
            Console.ReadLine();

        }

    }

    public class ApiService
    {
        public int Post()
        {
            HttpClient client = new HttpClient();
            Std std = new Std()
            {
                Name = "poriya",
                SurName = "vali",
                Age = 12

            };
            string content = JsonConvert.SerializeObject(std);
            HttpContent data = new StringContent(content, Encoding.UTF8, "application/json");
            var response = client.PostAsync("http://localhost:31831/api/Std", data).Result;
            string responseContent = response.Content.ReadAsStringAsync().Result;
            return int.Parse(responseContent);
        }
        public Std Put()
        {
            HttpClient client = new HttpClient();
            Std std = new Std()
            {
                StdId = 3,
                Name = "poriya",
                SurName = "h",
                Age = 14

            };
            string content = JsonConvert.SerializeObject(std);
            HttpContent data = new StringContent(content, Encoding.UTF8, "application/json");
            var response = client.PutAsync("http://localhost:31831/api/Std", data).Result;
            string responseContent = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Std>(responseContent); 
           
        }
        public List<Std> GetAll()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("http://localhost:31831/api/Std").Result;
            string content = response.Content.ReadAsStringAsync().Result;
            List<Std> result = JsonConvert.DeserializeObject<List<Std>>(content);
            return result;
        }

        public Std Get(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"http://localhost:31831/api/Std/{id}").Result;
            string content = response.Content.ReadAsStringAsync().Result;
            Std result = JsonConvert.DeserializeObject<Std>(content);
            return result;
        }

        public void Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync($"http://localhost:31831/api/Std/{id}").Result;
            string content = response.Content.ReadAsStringAsync().Result;
        }
    }
}
