using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanLibrary.Application.Authors.Commands.CreateAuthor;
using CleanLibrary.Application.Authors.Commands.DeleteAuthor;
using CleanLibrary.Application.Authors.Commands.UpdateAuthor;
using CleanLibrary.Application.Authors.Queries.GetAllAuthors;
using CleanLibrary.Application.Authors.Queries.GetAuthorById;

namespace CleanLibrary.Api.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var result = await _mediator.Send(new GetAllAuthorsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(Guid id)
        {
            var result = await _mediator.Send(new GetAuthorByIdQuery(id));
            return result != null ? Ok(result) : NotFound();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(Guid id, [FromBody] UpdateAuthorCommand command)
        {
            if (id != command.AuthorId)
                return BadRequest("ID mismatch");

            var result = await _mediator.Send(command);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var result = await _mediator.Send(new DeleteAuthorCommand(id));
            return result ? Ok() : NotFound();
        }
    }
}
