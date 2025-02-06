using FluentValidation;

namespace CleanLibrary.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Author name is required.")
                .MaximumLength(100)
                .WithMessage("Author name cannot exceed 100 characters.");
        }
    }
}
