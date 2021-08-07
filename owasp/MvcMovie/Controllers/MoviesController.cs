using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using MvcMovie.Models;
using MySqlConnector;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MySqlConnection _mySqlConnection;

        public MoviesController(MySqlConnection mySqlConnection)
        {
            _mySqlConnection = mySqlConnection;
            _mySqlConnection.Open();
        }

        // GET: Movies
        public async Task<IActionResult> Index(string genre)
        {
            using var cmd = _mySqlConnection.CreateCommand();

            if (string.IsNullOrEmpty(genre))
            {
                cmd.CommandText = $"SELECT `id`, `title`, `genre` FROM `Movie`";
            }
            else
            {
                cmd.CommandText = $"SELECT `id`, `title`, `genre` FROM `Movie` WHERE genre = '{genre}'";
                
                /*
                cmd.CommandText = @"SELECT `id`, `title`, `genre` FROM `Movie` WHERE genre = @genre";
                cmd.Parameters.Add(new MySqlParameter
                {
                    ParameterName = "@genre",
                    DbType = DbType.String,
                    Value = genre,
                });
                */
            }
            
            var movies = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return View(movies);
        }
        
        private async Task<List<Movie>> ReadAllAsync(DbDataReader reader)
        {
            var movies = new List<Movie>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var movie = new Movie()
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Genre = reader.GetString(2),
                    };
                    movies.Add(movie);
                }
            }
            return movies;
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            throw new NotImplementedException();
            
            /*
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
            */
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            throw new NotImplementedException();
            
            /*
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
            */
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            throw new NotImplementedException();
            
            /*
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
            */
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            throw new NotImplementedException();
            
            /*
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
            */
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            throw new NotImplementedException();
            
            /*
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
            */
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            throw new NotImplementedException();
            
            /*
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            */
        }

        private bool MovieExists(int id)
        {
            throw new NotImplementedException();
            
            /*
            return _context.Movie.Any(e => e.Id == id);
            */
        }
        
    }
}
