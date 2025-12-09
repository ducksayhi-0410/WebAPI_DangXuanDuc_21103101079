using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_DangXuanDuc_21103101079.Data;
using WebAPI_DangXuanDuc_21103101079.Models;

namespace WebAPI_DangXuanDuc_21103101079.Controllers
{
    [Route("api/[controller]")] // Định nghĩa đường dẫn là: api/books
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookContext _context;

        public BooksController(BookContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook()
        {
            return await _context.Book.ToListAsync();
        }

        // GET: api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Book.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, book);
        }

        // GET: api/books/maxprice
        [HttpGet("maxprice")]
        public async Task<ActionResult<Book>> GetMaxPriceBook()
        {
            var maxPriceBook = await _context.Book.OrderByDescending(b => b.Price).FirstOrDefaultAsync();
            if (maxPriceBook == null) return NotFound();
            return maxPriceBook;
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}