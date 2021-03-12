using Microsoft.AspNetCore.Mvc;
using MovieClientApp.Models;
using MovieClientApp.Povider;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieClientApp.Controllers
{
    public class BookTicketController : Controller
    {
        private readonly IBookProvider _provider;

        public BookTicketController(IBookProvider provider)
        {
            _provider = provider;
        }

        [HttpGet]
        public async Task<IActionResult> AllMovies()
        {
            IEnumerable<Movie> mlist ;
            var response= await _provider.AllMovies();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsoncontent = await response.Content.ReadAsStringAsync();
                mlist = JsonConvert.DeserializeObject<List<Movie>>(jsoncontent);
                return View(mlist);

            }
            return View();
        }

        [HttpGet]
        public IActionResult BookTicket()
        {

            string today = DateTime.Today.Day + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString() ;
           // Ticket t = new Ticket();
            ViewBag.Min = today;
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Index(Ticket ticket)
        {
            Ticket t = new Ticket();
            var response = await _provider.BookTicket(ticket);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsoncontent = await response.Content.ReadAsStringAsync();
                t = JsonConvert.DeserializeObject<Ticket>(jsoncontent);
                return View("CartAdded", t);

            }
            else
            {
                return View("CartNotAdded", t);
            }
           
           
        }
        [HttpPost]
        public async Task<IActionResult> BookTicket(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Ticket t = new Ticket();
            try
            {
                var response = await _provider.BookTicket(ticket);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsoncontent = await response.Content.ReadAsStringAsync();
                    t = JsonConvert.DeserializeObject<Ticket>(jsoncontent);
                    return View("CartAdded", t);
                }
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
            return View();
        }


        [HttpGet]
        public IActionResult CartAdded()
        {
            Ticket ticket = new Ticket();
            return View(ticket);
        }

        [HttpGet]

        public IActionResult CartNotAdded()

        {
            Ticket ticket = new Ticket();
            return View(ticket);

        }
    }
}
