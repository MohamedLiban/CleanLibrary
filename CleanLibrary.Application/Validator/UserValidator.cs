using FluentValidation;
using CleanLibrary.Domain.Models;

namespace CleanLibrary.Application.Validator
{
    public class UserValidator : AbstractValidator<User>
    
        {
            public UserValidator()
            {
                RuleFor(user => user.Username).NotEmpty();
                RuleFor(user => user.Email).NotEmpty().EmailAddress();
                RuleFor(user => user.PasswordHash).NotEmpty(); 
            }
        }

    }

