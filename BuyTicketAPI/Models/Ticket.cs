using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyTicketAPI.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string  MovieName { get; set; }
        public int Fare { get; set; }
        public DateTime Date { get; set; }
    }
}
