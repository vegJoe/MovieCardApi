using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCardApi.Data;
using MovieCardApi.Models.Dtos;
using MovieCardApi.Models.Entities;

namespace MovieCardApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieCardContext _context;

        public MoviesController(MovieCardContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            return await _context.Movie.ToListAsync();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }

        [HttpGet("{id:int}/details")]
        public async Task<ActionResult<MovieCardDetailsDto>> GetMovieDetails(int id)
        {
            var dto = await _context.Movie
                .Where(m => m.Id == id)
                .Select(m => new MovieCardDetailsDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Rating = m.Rating,
                    ReleaseDate = m.Releasedate,
                    Description = m.Description,
                    DirectorName = m.Director.Name,
                    Email = m.Director.ContactInformation.Email,
                    Phonenumber = m.Director.ContactInformation.Phonenumber,
                    Genre = string.Join(", ", m.Genres.Select(mg => mg.Genre.Name)), // Combine genres into a single string
                    Actors = m.Actors.Select(ma => new MovieActorsDto(ma.Actor.Name, ma.Actor.DateOfBirth))
                })
                .FirstOrDefaultAsync();

            return Ok(dto);
        }
    }
}
