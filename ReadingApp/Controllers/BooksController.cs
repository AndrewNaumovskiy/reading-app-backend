using ReadingApp.Models;
using ReadingApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace ReadingApp.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [EnableCors]
        [Route("")]
        public async Task<ActionResult<ResponseModel<GetBooksData, IError>>> GetBooks()
        {
            return Ok(new ResponseModel<GetBooksData, IError>()
            {
                Data = new GetBooksData(_bookService.GetBooks())
            });
        }
    }
}
