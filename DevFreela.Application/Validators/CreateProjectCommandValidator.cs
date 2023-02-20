using DevFreela.Application.Commands.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage("Título não pode ultrapassar o tamanho máximo de 30 caracteres!");

            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("Descrição não pode ultrapassar tamanho máximo de 255 caracteres");
        }
    }
}