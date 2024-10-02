using DevFreela.Application.Commands.InsertUser;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<InsertUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                    .WithMessage("Invalid e-mail");

            RuleFor(u => u.Birthdate)
                .Must(d => d < DateTime.Now.AddYears(-18))
                    .WithMessage("Must reached majority age");
        }
    }
}