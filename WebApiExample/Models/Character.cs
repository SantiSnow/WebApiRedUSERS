using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiExample.Models
{
    public class Character
    {
        public long Id { get; set; }
        private string Name { get; set; }
        private int Age { get; set; }
        private Planet Planet { get; set; }
        private Movie FirstAppearence { get; set; }
    }
}
