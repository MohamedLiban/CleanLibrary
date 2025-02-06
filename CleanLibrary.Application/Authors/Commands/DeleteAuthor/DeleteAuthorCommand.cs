using MediatR;
using System;

namespace CleanLibrary.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<bool>
    {
        public Guid AuthorId { get; }

        public DeleteAuthorCommand(Guid authorId)
        {
            AuthorId = authorId;
        }
    }
}
