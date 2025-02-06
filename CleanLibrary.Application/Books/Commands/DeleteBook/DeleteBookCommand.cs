using MediatR;

namespace CleanLibrary.Application.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest<bool>
    {
        public Guid BookId { get; }

        public DeleteBookCommand(Guid bookId)
        {
            BookId = bookId;
        }
    }
}
