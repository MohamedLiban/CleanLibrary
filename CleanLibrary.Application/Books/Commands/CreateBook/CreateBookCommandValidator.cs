using FluentValidation;
using CleanLibrary.Application.Books.Commands.CreateBook;

namespace CleanLibrary.Application.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
            RuleFor(x => x.AuthorId).NotEmpty().WithMessage("AuthorId is required.");
        }
    }
}
