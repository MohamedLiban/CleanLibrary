using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanLibrary.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Guid>
    {
        private readonly IBookRepository _repository;
        private readonly IValidator<Book> _validator;

        public CreateBookCommandHandler(IBookRepository repository, IValidator<Book> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book(Guid.NewGuid(), request.Title, request.AuthorId);

            var validationResult = await _validator.ValidateAsync(book, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            await _repository.AddBookAsync(book);
            return book.Id;
        }
    }
}
