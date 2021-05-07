using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Data;
using MovieAPI.Models;
using MovieAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DirectorsController : ControllerBase
	{
		// GET		/api/tags[text][type][order]
		// GET		/api/tags/{id}
		// PUT		/api/tags/{id} + body
		// PUT		/api/tags/{id}/text + body
		// POST		/api/tags+body
		// DELETE	/api/tags/{id}
		// GET		/api/tags/{id}/quotes
		// GET		/api/quotes?[text][tag]
		// GET		/api/quotes/{id}
		// GET		/api/quotes/{id}/tags
		// GET		/api/quotes/count

		private readonly MoviesDbContext _context;

		public DirectorsController(MoviesDbContext context)
		{
			_context = context;
		}

		// GET:		api/Directors
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Director>>> GetDirectors(string name, string order)
		{

			IQueryable<Director> directors = _context.Directors;
			if (!String.IsNullOrEmpty(name))
				directors = directors.Where(d => d.FirstName.Contains(name) || d.LastName.Contains(name));

			directors = order.ToLower() switch
			{
				"firstname_desc" => directors.OrderByDescending(d => d.FirstName),
				"firstname" => directors.OrderBy(d => d.FirstName),
				"lastname_desc" => directors.OrderByDescending(d => d.LastName),
				_ => directors.OrderBy(d => d.LastName )
			};

			return await directors.ToListAsync();
		}

		// GET:		api/Directors/3
		[HttpGet("{id}")]
		public async Task<ActionResult<Director>> GetDirector(int id)
		{
			var director = await _context.Directors.FindAsync(id);

			if (director == null)
			{
				return NotFound("director not found");
			}

			return Ok(director);
		}

		// PUT:		api/Directors/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutDirector(int id, Director director)
		{
			if (id != director.Id)
			{
				return BadRequest();
			}

			_context.Entry(director).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!DirectorExists(id))
				{
					return NotFound("director not found");
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST:	api/Directors
		[HttpPost]
		public async Task<ActionResult<Director>> CreateMovie(DirectorIM director)
		{
			if (String.IsNullOrEmpty(director.FirstName) || String.IsNullOrEmpty(director.LastName))
			{
				return BadRequest("Empty name");
			}

			ICollection<Movie> movies;
			Director newDirector;
			try
			{///////////////////////
				movies = await _context.Movies.Where(m => director.MovieIds.Contains(m.id)).ToListAsync();
				newDirector = new Director { FirstName = director.FirstName, LastName = director.LastName, Movies = movies};
			}
			catch (Exception)
			{
				throw;
			}

			

			_context.Directors.Add(newDirector);
			
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetDirector", new { id = newDirector.Id }, newDirector);

		}

		// DELETE:	api/Directors/4
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteDirector(int id)
		{
			var director = await _context.Directors.FindAsync(id);
			if (director == null)
			{
				return NotFound();
			}

			_context.Directors.Remove(director);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		// GET: api/Directors/5/movies
		[HttpGet("{id}/movies")]
		public async Task<ActionResult<IEnumerable<Movie>>> GetDirectorMovies(int id)
		{
			var director = await _context.Directors.FindAsync(id);
			if (director == null)
			{
				return NotFound();
			}
			return await _context.Movies.Where(m => m.Directors.Contains(director)).ToListAsync();
		}

	








		private bool DirectorExists(int id)
		{
			return _context.Directors.Any(d => d.Id == id);
		}

	}
}
