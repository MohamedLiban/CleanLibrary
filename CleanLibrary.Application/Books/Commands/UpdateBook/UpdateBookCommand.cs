using MediatR;
using System;

namespace CleanLibrary.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest<bool>
    {
        public Guid BookId { get; }
        public string Title { get; }
        public Guid AuthorId { get; }

        public UpdateBookCommand(Guid bookId, string title, Guid authorId)
        {
            BookId = bookId;
            Title = title;
            AuthorId = authorId;
        }
    }
}
