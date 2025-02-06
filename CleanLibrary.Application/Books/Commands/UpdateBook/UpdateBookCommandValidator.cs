using FluentValidation;

namespace CleanLibrary.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty()
                .WithMessage("Book title is required.")
                .MaximumLength(200)
                .WithMessage("Book title cannot exceed 200 characters.");

            RuleFor(b => b.AuthorId)
                .NotEmpty()
                .WithMessage("Author ID is required.");
        }
    }
}
