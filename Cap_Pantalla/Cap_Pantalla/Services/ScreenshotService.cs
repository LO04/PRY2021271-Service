using Cap_Pantalla.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cap_Pantalla.Services
{
    public class Screenshot : IScreenshotService
    {
        private readonly string baseUrl = "https://montracapi20220413154050.azurewebsites.net/api/";
        // for now service work with token & userId
        private readonly string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE2NTE0MDY3MTksImV4cCI6MTY1MjAxMTUxOSwiaWF0IjoxNjUxNDA2NzE5fQ.ZN9NhmH82eHEb7k1lhBtFJ2P385A4QJQhcE8E6eFGPg";
        private readonly int userId = 1;

        public Screenshot()
        {
        }

        public async Task<dynamic> SendScreenshot(ScreenshotRequest request)
        {
            try
            {
                var path = "screenshot";
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
