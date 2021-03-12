using MovieClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieClientApp.Povider
{
    public interface IBookProvider
    {
        public Task<HttpResponseMessage> BookTicket(Ticket ticket);
        public Task<HttpResponseMessage> AllMovies();
    }
}
