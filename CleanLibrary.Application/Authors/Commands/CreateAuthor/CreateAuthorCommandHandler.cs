using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Domain.Models;

namespace CleanLibrary.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Author>
    {
        private readonly IAuthorRepository _repository;
        private readonly IValidator<Author> _validator;

        public CreateAuthorCommandHandler(IAuthorRepository repository, IValidator<Author> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var newAuthor = new Author(Guid.NewGuid(), request.Name);
            await _repository.AddAuthorAsync(newAuthor);
            return newAuthor;
        }
    }
}
