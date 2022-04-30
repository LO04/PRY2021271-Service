using HistorialNavegación.Models;
using HistorialNavegación.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HistorialNavegación.Services
{
    public class UrlService : IUrlService
    {
        private readonly string baseUrl = "https://montracapi20220413154050.azurewebsites.net/api/";
        // for now service work with token & userId
        private readonly string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE2NTA4Mjk3MjQsImV4cCI6MTY1MTQzNDUyMywiaWF0IjoxNjUwODI5NzI0fQ.aZOuLECyh4lfHkw5md2fmdi0nbpDDKWWCNXzh7j8mng";
        private readonly int userId = 2;

        public UrlService()
        {
        }

        public async Task<dynamic> SendUrl(UrlRequest request)
        {
            try
            {
                var path = "url";
                request.UserId = userId;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(path, content);
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
