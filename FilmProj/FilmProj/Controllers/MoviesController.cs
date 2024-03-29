﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmProj.Models;
using FilmProj.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FilmProj.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult UserMovies()
        {
            return View(_context.Movie.ToList()); //testar bara jujst nu.
        }


        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movie.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
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

            return View(new MovieVm { Movie = movie, UserId = User.Identity });
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Director,Description,ImgUrl")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
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
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Director,Description, ImgUrl")] Movie movie)
        {
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
                return View("Details", movie);
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
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
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }

        public async Task<IActionResult> AddToWatch(string name, int movieid)
        {
            
            var movie = await _context.Movie.FindAsync(movieid);
            var userExists = _context.UserMovies.Any(e => e.UserName == name);
            if (!userExists)
            {
                _context.UserMovies.Add(new UserMovies { UserName = name });
                _context.SaveChanges();
            }
            var rrr = _context.UserMovies.Include(x => x.ToWatch).SingleOrDefault(user => user.UserName == name);
            rrr.ToWatch.Add(movie);
            _context.SaveChanges();

            ViewBag.Chan = "towatch";
            var ll = new MovieVm { Movie = movie, UserId= User.Identity };
            return View($"Details", ll);
        }


        public async Task<IActionResult> AddWatched(string name, int movieid)
        {

            var movie = await _context.Movie.FindAsync(movieid);
            var userExists = _context.UserMovies.Any(e => e.UserName == name);
            if (!userExists)
            {
                _context.UserMovies.Add(new UserMovies { UserName = name });
                _context.SaveChanges();
            }
            var rrr = _context.UserMovies.Include(x => x.Watched).SingleOrDefault(user => user.UserName == name);
            rrr.Watched.Add(movie);
            _context.SaveChanges();

            ViewBag.Chan = "watched";
            var ll = new MovieVm { Movie = movie, UserId = User.Identity };
            return View($"Details", ll);
        }
    }
}
