using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Quality.Measurement.System.Shared.Models;

namespace Quality.Measurement.System.ConsoleApp
{
    static class Program
    {
        /// <summary>
        /// The client
        /// </summary>
        private static readonly HttpClient Client = new HttpClient();
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        static void Main()
        {
            Init();
            RunAsync();
            Environment.Exit(0);
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private static void Init()
        {
            Client.BaseAddress = new Uri("http://localhost:60048/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.Timeout = TimeSpan.FromMilliseconds(1000000);
        }

        /// <summary>
        /// Runs the asynchronous.
        /// </summary>
        static void RunAsync()
        {
            RunUserTest();
            RunRoleTest();
           
        }

        /// <summary>
        /// Runs the role test.
        /// </summary>
        private static void RunRoleTest()
        {
            Role roleObj = GetApiResponse<Role>("Role", "Get", 1);
            if (roleObj != null)
            {
                Console.WriteLine("RoleName From RoleId: {0}", roleObj.RoleName);
            }

            roleObj = new Role()
            {
                RoleName = "Admin",
                RoleId = 2
            };

            roleObj = PostApiResponse<Role>("Role", "Post", roleObj);
            if (roleObj != null)
            {
                Console.WriteLine("RoleName From RoleId: {0}", roleObj.RoleName);
            }
        }

        /// <summary>
        /// Runs the user test.
        /// </summary>
        private static void RunUserTest()
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

        /// <summary>
        /// Gets the API response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiController">The API controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private static T GetApiResponse<T>(string apiController, string action, long? id)
        {
            string requestUri = "api/" + apiController + "/" + action + "/" + id;
            HttpResponseMessage response = Client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }

        /// <summary>
        /// Gets the API response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiController">The API controller.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public static T GetApiResponse<T>(string apiController, string action)
        {
            string requestUri = "api/" + apiController + "/" + action;
            HttpResponseMessage response = Client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }

        /// <summary>
        /// Gets the API response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiController">The API controller.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static T GetApiResponse<T>(string apiController, long? id)
        {
            string requestUri = "api/" + apiController + "/" + id;
            HttpResponseMessage response = Client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }

        /// <summary>
        /// Gets the API response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiController">The API controller.</param>
        /// <returns></returns>
        public static T GetApiResponse<T>(string apiController)
        {
            string requestUri = "api/" + apiController;
            HttpResponseMessage response = Client.GetAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }

        /// <summary>
        /// Posts the API response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiController">The API controller.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static T PostApiResponse<T>(string apiController, object data)
        {
            string requestUri = "api/" + apiController;
            var content = data;
            HttpResponseMessage response = Client.PostAsJsonAsync(requestUri, content).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }


        /// <summary>
        /// Deletes the API response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiController">The API controller.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static T DeleteApiResponse<T>(string apiController, string id)
        {
            string requestUri = "api/" + apiController + "/" + id;
            HttpResponseMessage response = Client.DeleteAsync(requestUri).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }

        /// <summary>
        /// Posts the API response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiController">The API controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static T PostApiResponse<T>(string apiController, string action, object data)
        {
            string requestUri = "api/" + apiController + "/" + action;
            var content = data;
            HttpResponseMessage response = Client.PostAsJsonAsync(requestUri, content).Result;
            if (response.IsSuccessStatusCode)
                return (T)response.Content.ReadAsAsync(typeof(T)).Result;
            return default(T);
        }


        /// <summary>
        /// Deletes the API response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiController">The API controller.</param>
        /// <param name="action">The action.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
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