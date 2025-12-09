using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMVC_DangXuanDuc_21103101079.Models;
using WebMVC_DangXuanDuc_21103101079.Data;
using WebMVC_DangXuanDuc_21103101079.Repositories;

namespace WebMVC_DangXuanDuc_21103101079.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _repository;
        private readonly MovieContext _context;

        public MoviesController(IMovieRepository repository)
        {
            _repository = repository;
        }
        // GET: Movies
        public async Task<IActionResult> Index()
        {
              return View(await _repository.GetAllAsync());
        }


        public async Task<IActionResult> SearchByDirector(string keyword)
        {
            var movies = await _repository.SearchByDirectorAsync(keyword);
            ViewData["CurrentFilter"] = keyword;

            return View(movies);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var movie = await _repository.GetByIdAsync(id ?? 0);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
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
        public async Task<IActionResult> Create([Bind("Id,Director,Title,ReleaseYear,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _repository.GetByIdAsync(id);
            if (ModelState.IsValid)
            {
                
                if (movie == null)
                {
                    return NotFound();
                }
               
            }
            return View(movie);

        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Director,Title,ReleaseYear,Rating")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _repository.UpdateAsync(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var existingMovie = await _repository.GetByIdAsync(movie.Id);
                    if (existingMovie == null)
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
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var movie = await _repository.GetByIdAsync(id ?? 0);
            if (id == null )
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
            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
