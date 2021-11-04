using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiExample.Models
{
    public class Character
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        //public long PlanetId { get; set; }
        public long MovieId { get; set; }
        //public Planet Planet { get; set; }
        public Movie FirstAppearence { get; set; }
    }
}
