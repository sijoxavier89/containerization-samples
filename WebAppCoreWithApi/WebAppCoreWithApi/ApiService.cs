using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebAppCoreWithApi
{
    /// <summary>
    /// This is a service class to connect to web api 
    /// </summary>
    public class ApiService
    {
        bool isContainer = false;
        // webapicore is the service name which defined in the
        // docker compose file ; port expose is 80 in the dockerfile --EXPOSE 80
        string containerHost = "http://webapicore:80/";

        // to connect outside the container
        string localHost = "http://localhost:51355/";

        public ApiService()
        {
        }


        /// <summary>
        /// Sample method which fethces a string message from 
        /// web api
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string FindCatalogItem(int? id)

        {
            string item = null;

            using (var client = new HttpClient())

            {
                if (isContainer)

                {
                    client.BaseAddress = new Uri(containerHost);
                }
                else
                {
                    client.BaseAddress = new Uri(localHost);
                }
                //HTTP GET
                var responseTask = client.GetAsync("api/values/" + id);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)

                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();
                    item = readTask.Result;
                }
            }

            return item;
        }
    }
}
