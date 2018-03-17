using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace opapProject.Services
{
    public class WebApiFetch :IWebApiFetch
    {
        //HttpClient is intended to be instantiated once and re-used throughout the life 
        //of an application.Instantiating an HttpClient class for every request will exhaust 
        //the number of sockets available under heavy loads.This will result in 
        //SocketException errors. Below is an example using HttpClient correctly.
        private static readonly HttpClient client;
        public IConfiguration _iconfiguration;

        static WebApiFetch()
        {
            client = new HttpClient();
        }

        //Constructor depedency injection for iconfiguration so as to read from 
        //appsetings.json
        public WebApiFetch(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        public async Task<string> WebApiFetchAsync(string path)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                var error = $"Message : {e.Message}";
                return error;

            }
        }
    }
}
