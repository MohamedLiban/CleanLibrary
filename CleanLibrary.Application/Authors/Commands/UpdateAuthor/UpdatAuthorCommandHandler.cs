using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanLibrary.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, bool>
    {
        private readonly IAuthorRepository _repository;
        private readonly IValidator<Author> _validator;

        public UpdateAuthorCommandHandler(IAuthorRepository repository, IValidator<Author> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetAuthorByIdAsync(request.AuthorId);
            if (author == null) return false;

            author.UpdateName(request.Name);

            var validationResult = await _validator.ValidateAsync(author, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return await _repository.UpdateAuthorAsync(author);
        }
    }
}
