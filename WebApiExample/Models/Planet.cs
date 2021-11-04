using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiExample.Models
{
    public class Planet
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public long MovieId { set; get; }
        [ForeignKey("MovieId")]
        public Movie FirstAppearence { get; set; }
    }
}
