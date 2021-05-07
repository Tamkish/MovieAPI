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
	public class MoviesController : ControllerBase
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

		public MoviesController(MoviesDbContext context)
		{
			_context = context;
		}

		// GET:		api/Movies
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Movie>>> GetMovies(string name, string order)
		{
			IQueryable<Movie> movies = _context.Movies;
			if (!String.IsNullOrEmpty(name))
				movies = movies.Where(m => m.Name.Contains(name));

			movies = order switch
			{
				"name_desc" => movies.OrderByDescending(m => m.Name),
				_ => movies.OrderBy(m => m.Name)
			};

			return await movies.ToListAsync();
		}

		// GET:		api/Movies/3
		[HttpGet("{id}")]
		public async Task<ActionResult<Movie>> GetMovie(int id)
		{
			var movie = await _context.Movies.FindAsync(id);

			if (movie == null)
			{
				return NotFound("movie not found");
			}

			return Ok(movie);
		}

		// PUT:		api/Movies/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutMovie(int id, Movie movie)
		{
			if (id != movie.id)
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
					return NotFound("tag not found");
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST:	api/Movies
		[HttpPost]
		public async Task<ActionResult<Movie>> CreateMovie(MovieIM movie)
		{
			DateTime newReleaseDate;
			try
			{
				newReleaseDate = DateTime.Parse(movie.ReleaseYearString);
			}
			catch (Exception)
			{
				return BadRequest("wrong datetime");
				throw;
			}

			ICollection<Director> directors;
			Movie newMovie;
			try
			{
				directors = await _context.Directors.Where(d => movie.DirectorIds.Contains(d.Id)).ToListAsync();
				newMovie = new Movie { Name = movie.Name, ReleaseDate = newReleaseDate, Directors = directors};
			}
			catch (Exception)
			{
				throw;
			}

			

			_context.Movies.Add(newMovie);
			
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetMovie", new { id = newMovie.id }, newMovie);

		}

		// DELETE:	api/Movies/4
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMovie(int id)
		{
			var movie = await _context.Movies.FindAsync(id);
			if (movie == null)
			{
				return NotFound();
			}

			_context.Movies.Remove(movie);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		// GET: api/Movies/5/directors
		[HttpGet("{id}/directors")]
		public async Task<ActionResult<IEnumerable<Director>>> GetMovieDirectors(int id)
		{
			var movie = await _context.Movies.FindAsync(id);
			if (movie == null)
			{
				return NotFound();
			}
			return await _context.Directors.Where(d => d.Movies.Contains(movie)).ToListAsync();
		}








		private bool MovieExists(int id)
		{
			return _context.Movies.Any(m => m.id == id);
		}

	}
}
