using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiExample.Models;

namespace WebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly StarWarsContext _context;

        public CharactersController(StarWarsContext context)
        {
            _context = context;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return await _context.Characters
                .Include( i => i.FirstAppearence )
                .ToListAsync();
        }

        // GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(long id)
        {
            var character = await _context.Characters
                .Include( i => i.FirstAppearence )
                .FirstOrDefaultAsync(i => i.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }

        // GET: api/SearchCharacters/

        [HttpGet("getCharacter/{name}")] // GET /api/Characters/getCharacter/name
        public string GetCharactersName() //async Task<ActionResult<Character>> GetCharacterByName(string name)
        {
            /*
            var character = await _context.Characters
                .Include(i => i.FirstAppearence)
                .FirstOrDefaultAsync(i => i.Name == name);

            if (character == null)
            {
                return NotFound();
            }*/

            return "character";
        }

        
        [HttpPost] // /api/Characters/getCharacter
        [Route("~/api/getCharacterByName")]
        public async Task<ActionResult<Character>> GetCharacterByName(CharacterName searched)
        {

            var character = await _context.Characters
                .Include(i => i.FirstAppearence)
                //.FirstOrDefaultAsync(i => i.Name.Contains(searched.Name));
                .FirstOrDefaultAsync(i => EF.Functions.Like(i.Name, "%a%"));

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }

        // PUT: api/Characters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(long id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Characters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCharacter), new { id = character.Id }, character);
        }

        // DELETE: api/Characters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Character>> DeleteCharacter(long id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return character;
        }

        private bool CharacterExists(long id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
