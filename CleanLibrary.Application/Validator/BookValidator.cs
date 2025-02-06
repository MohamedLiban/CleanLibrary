using FluentValidation;
using CleanLibrary.Domain.Models;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
        RuleFor(x => x.AuthorId).NotEmpty().WithMessage("Author ID is required.");
    }
}
