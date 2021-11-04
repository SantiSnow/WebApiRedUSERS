using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiExample.Models
{
    public class Movie
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        //private List<Character> Characters { get; set; }
        public ICollection<Planet> Planets { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
