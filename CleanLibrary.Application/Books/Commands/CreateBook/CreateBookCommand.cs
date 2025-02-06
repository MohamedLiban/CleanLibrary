using MediatR;
using System;

namespace CleanLibrary.Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<Guid>
    {
        public string Title { get; }
        public Guid AuthorId { get; }

        public CreateBookCommand(string title, Guid authorId)
        {
            Title = title;
            AuthorId = authorId;
        }
    }
}
