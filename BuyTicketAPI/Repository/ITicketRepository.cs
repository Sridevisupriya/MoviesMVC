using BuyTicketAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicketAPI.Repository
{
    public interface ITicketRepository
    {
        public Ticket BookTicket(string movieName , DateTime dateTime);
    }
}
