using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiExample.Models
{
    public class StarWarsContext : DbContext 
    {
        public StarWarsContext(DbContextOptions<StarWarsContext> options) 
            : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Planet> Planets { get; set; }
    }
}
