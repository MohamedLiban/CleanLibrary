using MediatR;
using CleanLibrary.Domain.Models;

namespace CleanLibrary.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<Author>
    {
        public string Name { get; }

        public CreateAuthorCommand(string name)
        {
            Name = name;
        }
    }
}
