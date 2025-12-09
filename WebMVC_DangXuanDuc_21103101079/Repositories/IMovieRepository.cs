using System.Collections.Generic;
using System.Threading.Tasks;
using WebMVC_DangXuanDuc_21103101079.Models;


namespace WebMVC_DangXuanDuc_21103101079.Repositories
{
    public interface  IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(int id);
        Task<IEnumerable<Movie>> SearchByDirectorAsync(string keyword);
    }
}
