using System;
using System.Text.RegularExpressions;
using DevFreela.Application.Commands.CreateUser;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("E-mail não é válido!");

            RuleFor(u => u.Password)
                .Must(ValidPassword)
                .WithMessage("Senha não é válida! Deve conter pelo menos um caractere especial, um número, letra maiuscula e minuscula");
            
            RuleFor(u => u.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome é obrigatório!");
        }

        public bool ValidPassword(string password){
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.Match(password).Success;
        }
    }
}