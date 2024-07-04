using ReadingApp.Models;
using ReadingApp.Services;
using ReadingApp.Models.RequestModels;
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
            var books = await _bookService.GetBooks();
            return Ok(new ResponseModel<GetBooksData, IError>()
            {
                Data = new GetBooksData(books)
            });
        }

        [HttpGet]
        [EnableCors]
        [Route("{id}")]
        public async Task<ActionResult<ResponseModel<GetBookInformationData, IError>>> GetBookInfo(int id, [FromQuery] int userId)
        {
            var info = await _bookService.GetBookById(id, userId);
            return Ok(new ResponseModel<GetBookInformationData, IError>()
            {
                Data = new GetBookInformationData(info)
            });
        }

        [HttpPost]
        [EnableCors]
        [Route("updateRate")]
        public async Task<ActionResult<ResponseModel<UpdateUserRateData,IError>>> UpdateUserRate([FromBody] UpdateUserRateRequestModel body)
        {
            var userRate = await _bookService.UpdateUserRate(body);
            return Ok(new ResponseModel<UpdateUserRateData, IError>()
            {
                Data = new UpdateUserRateData(userRate)
            });
        }
    }
}
