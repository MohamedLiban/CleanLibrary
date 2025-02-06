
using CleanLibrary.Application.Books.Commands.CreateBook;
using CleanLibrary.Application.Books.Commands.DeleteBook;
using CleanLibrary.Application.Books.Commands.UpdateBook;
using CleanLibrary.Application.Books.Queries.GetAllBooks;
using CleanLibrary.Application.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanLibrary.Application.Books.Queries.GetBookById;

namespace CleanLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/books")]
    [Produces("application/json")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var query = new GetBookByIdQuery(id);
            var book = await _mediator.Send(query);

            if (book == null)
                return NotFound("Book not found.");

            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateBookCommand command)
        {
            if (id != command.BookId)
                return BadRequest("ID mismatch");

            var result = await _mediator.Send(command);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var result = await _mediator.Send(new DeleteBookCommand(id));
            return result ? Ok() : NotFound();
        }
    }
}
