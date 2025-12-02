using Library.Contracts;
using Library.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookResponse>>> GetBooks()
        {
            try
            {
                var books = await _libraryService.GetAllBooks();

                var response = books.Select(book => new BookResponse(
                    book.Id,
                    book.AuthorId,
                    book.Title,
                    book.ImageUrl,
                    book.Price));

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }  
    }
}
