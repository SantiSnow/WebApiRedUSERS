using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiExample.Models
{
    public class Planet
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        private Movie FirstAppearence { get; set; }
    }
}
