using BuyTicketAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BuyTicketAPI.Repository
{
    public class TicketRepository : ITicketRepository
    {

        private readonly TicketDbContext _db;
        public TicketRepository(TicketDbContext db)
        {
            _db = db;
        }
        public Ticket BookTicket( string movieName, DateTime dateTime)
        {
            using (HttpClient client = new HttpClient())

            {

                client.BaseAddress = new Uri("https://localhost:44396/");

                client.DefaultRequestHeaders.Accept.Clear();

                var contentType = new MediaTypeWithQualityHeaderValue("application/json");

                client.DefaultRequestHeaders.Accept.Add(contentType);

                HttpResponseMessage response = client.GetAsync("/api/Movies/GetMovieDetails/" + movieName).Result;

                string apiResponse = response.Content.ReadAsStringAsync().Result;

                //var value = response.Content.ReadAsStringAsync().Result;
                Movie m2 = JsonConvert.DeserializeObject<Movie>(apiResponse);
                if (m2 != null)
                {
                    Ticket ticket = new Ticket()
                    {
                        MovieId = m2.Id,
                        MovieName = m2.MovieName,
                        Fare=m2.Fare,
                        Date = DateTime.Now
                    };
                    _db.Tickets.Add(ticket);
                    _db.SaveChanges();
                    return ticket;
                }
                /* List<Movie> m= JsonConvert.DeserializeObject<List<Movie>>(apiResponse);
                 Ticket ticket = new Ticket();
                 foreach (Movie item in m)
                 {
                     if(item.MovieName==movieName && item.status==true)
                     {

                         ticket.MovieId = item.Id;
                         ticket.MovieName = item.MovieName;
                         ticket.Date = dateTime;
                         _db.Tickets.Add(ticket);
                         _db.SaveChanges();
                         return ticket;
                     }
                 }



             }
             /*if (m != null)
             {
                 Ticket ticket = new Ticket()
                 {
                     MovieId = m.Id,
                     MovieName = m.MovieName,
                     Date = DateTime.Now
                 };
                 _db.Tickets.Add(ticket);
                 return ticket;
             }*/


                return null;
            }
        }
    }
}
