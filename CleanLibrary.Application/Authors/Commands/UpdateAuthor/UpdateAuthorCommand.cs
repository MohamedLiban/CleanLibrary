using MediatR;

namespace CleanLibrary.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<bool>
    {
        public Guid AuthorId { get; }
        public string Name { get; }

        public UpdateAuthorCommand(Guid authorId, string name)
        {
            AuthorId = authorId;
            Name = name;
        }
    }
}
