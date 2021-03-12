using MovieClientApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MovieClientApp.Povider
{
    public class BookProvider : IBookProvider
    {
        public async Task<HttpResponseMessage> AllMovies()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44396/");
                client.DefaultRequestHeaders.Accept.Clear();
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                var response = await client.GetAsync("/api/Movies/GetAllMoviesDetails" );
                return response;
            }
        }

        public async Task<HttpResponseMessage> BookTicket(Ticket ticket)
        {
           using(HttpClient client=new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44331/");
                var jsonstring = JsonConvert.SerializeObject(ticket);
                var obj = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/api/BuyTicket/BookTicket/", obj);
                return response;
            }
        }
    }
}
