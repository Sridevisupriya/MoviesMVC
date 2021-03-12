using BuyTicketAPI.Models;
using BuyTicketAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyTicketController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        public BuyTicketController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpPost]
        [Route("BookTicket")]
        public IActionResult BookTicket([FromBody]Ticket ticket)
        {
            var ticket1 = _ticketRepository.BookTicket(ticket.MovieName, ticket.Date);
            if(ticket1==null)
            {
                return BadRequest();
            }
            return Ok(ticket1);
        }
    }
}
