using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Quality.Measurement.System.Shared.Models;

namespace Quality.Measurement.System.ConsoleApp
{
    static class Program
    {
        private static readonly HttpClient Client = new HttpClient();
        static void Main()
        {
            Init();
            RunAsync();
            Environment.Exit(0);
        }

        private static void Init()
        {
            Client.BaseAddress = new Uri("http://localhost:60048/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.Timeout = TimeSpan.FromMilliseconds(1000000);
        }

        static  void RunAsync()
        {
            User userObj = GetApiResponse<User>("User", "Get", 1);
            if (userObj != null)
            {
                Console.WriteLine("UserName From UserId: {0}", userObj.UserName);
            }
            userObj = new User()
            {
                UserName = "Vishal",
                UserId = 2,
                FirstName = "Vishal",
                LastName = "Soni"
            };

            userObj = PostApiResponse<User>("User", "Post", userObj);
            if (userObj != null)
            {
                Console.WriteLine("UserName From UserId: {0}", userObj.UserName);
            }
        }

        private static T GetApiResponse<T>(string apiController, string action, long? id)
        {
            string requestUri = "api/" + apiController + "/" + action + "/" + id;
            HttpResponseMessage response = Client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }

        public static T GetApiResponse<T>(string apiController, string action)
        {
            string requestUri = "api/" + apiController + "/" + action;
            HttpResponseMessage response = Client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }

        public static T GetApiResponse<T>(string apiController, long? id)
        {
            string requestUri = "api/" + apiController + "/" + id;
            HttpResponseMessage response = Client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }

        public static T GetApiResponse<T>(string apiController)
        {
            string requestUri = "api/" + apiController;
            HttpResponseMessage response = Client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }

        public static T PostApiResponse<T>(string apiController, object data)
        {
            string requestUri = "api/" + apiController;
            var content = data;
            HttpResponseMessage response = Client.PostAsJsonAsync(requestUri, content).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }


        public static T DeleteApiResponse<T>(string apiController, string id)
        {
            string requestUri = "api/" + apiController + "/" + id;
            HttpResponseMessage response = Client.DeleteAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }

        private static T PostApiResponse<T>(string apiController, string action, object data)
        {
            string requestUri = "api/" + apiController + "/" + action;
            var content = data;
            HttpResponseMessage response = Client.PostAsJsonAsync(requestUri, content).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }


        public static T DeleteApiResponse<T>(string apiController, string action, string id)
        {
            string requestUri = "api/" + apiController + "/" + action + "/" + id;
            HttpResponseMessage response = Client.DeleteAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }
    }
}