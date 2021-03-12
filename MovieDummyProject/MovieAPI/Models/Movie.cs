using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string  MovieName { get; set; }
        public int Fare { get; set; }
        public bool status { get; set; }
    }
}
