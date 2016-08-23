using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Quality.Measurement.System.Shared.Models;

namespace Quality.Measurement.System.ConsoleApp
{
    class Program
    {
        private static readonly HttpClient _client = new HttpClient();
        static void Main()
        {
            Init();
            RunAsync().Wait();
            Environment.Exit(0);
        }

        private static void Init()
        {
            _client.BaseAddress = new Uri("http://localhost:60048/");
            _client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));
            _client.Timeout = TimeSpan.FromMilliseconds(1000000);
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
                User userObj = GetApiResponse<User>("User","Get",1);
                if (userObj != null)
                {
                    Console.WriteLine("UserName From UserId: {0}", userObj.UserName);
                }
                userObj = new User()
                {
                    UserName = "Vishal",
                    UserId = 1,
                };

                userObj = PostApiResponse<User>("User", "Post", userObj);
            }
        }

        public static T GetApiResponse<T>(string apiController, string action, long? id)
        {
            string requestUri = "api/" + apiController + "/" + action + "/" + id;
            HttpResponseMessage response = _client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }

        public static T GetApiResponse<T>(string apiController, string action)
        {
            string requestUri = "api/" + apiController + "/" + action;
            HttpResponseMessage response = _client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }

        public static T GetApiResponse<T>(string apiController, long? id)
        {
            string requestUri = "api/" + apiController + "/" + id;
            HttpResponseMessage response = _client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }

        public static T GetApiResponse<T>(string apiController)
        {
            string requestUri = "api/" + apiController;
            HttpResponseMessage response = _client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }

        public static T PostApiResponse<T>(string apiController, object data)
        {
            string requestUri = "api/" + apiController;
            var content = data;
            HttpResponseMessage response = _client.PostAsJsonAsync(requestUri, content).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }


        public static T DeleteApiResponse<T>(string apiController, string id)
        {
            string requestUri = "api/" + apiController + "/" + id;
            HttpResponseMessage response = _client.DeleteAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }

        public static T PostApiResponse<T>(string apiController, string action, object data)
        {
            string requestUri = "api/" + apiController + "/" + action;
            var content = data;
            HttpResponseMessage response = _client.PostAsJsonAsync(requestUri, content).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }


        public static T DeleteApiResponse<T>(string apiController, string action, string id)
        {
            string requestUri = "api/" + apiController + "/" + action + "/" + id;
            HttpResponseMessage response = _client.DeleteAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }
    }
}