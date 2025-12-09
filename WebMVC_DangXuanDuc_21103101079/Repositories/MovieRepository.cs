using Microsoft.EntityFrameworkCore;
using WebMVC_DangXuanDuc_21103101079.Models;
using WebMVC_DangXuanDuc_21103101079.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


using WebMVC_DangXuanDuc_21103101079.Data;

namespace WebMVC_DangXuanDuc_21103101079.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;

        public MovieRepository(MovieContext context)
        {
            _context = context;
        }
        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movie.ToListAsync();
        }
        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movie.FindAsync(id);
        }
        public async Task AddAsync(Movie movie)
        {
            _context.Add(movie);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Movie movie)
        {
            _context.Update(movie);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Movie>> SearchByDirectorAsync(string keyword)
        {
          var query = _context.Movie.AsQueryable();
            if (!string.IsNullOrEmpty(keyword)) {
                return await query
                    .Where(m => m.Director.Contains(keyword))
                    .ToListAsync();
            }
            return await query.OrderByDescending(m => m.Rating).ToListAsync();
        }
    }
}
