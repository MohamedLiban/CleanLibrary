using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanLibrary.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly IBookRepository _repository;
        private readonly IValidator<Book> _validator;

        public UpdateBookCommandHandler(IBookRepository repository, IValidator<Book> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetBookByIdAsync(request.BookId);
            if (book == null) return false;

            book.UpdateTitle(request.Title);


            var validationResult = await _validator.ValidateAsync(book, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return await _repository.UpdateBookAsync(book);
        }
    }
}
