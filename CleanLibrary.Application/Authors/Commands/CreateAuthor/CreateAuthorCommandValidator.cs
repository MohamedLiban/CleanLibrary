using FluentValidation;
using CleanLibrary.Domain.Models;

namespace CleanLibrary.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Author name is required.")
                .MaximumLength(100)
                .WithMessage("Author name cannot exceed 100 characters.");
        }
    }
}
