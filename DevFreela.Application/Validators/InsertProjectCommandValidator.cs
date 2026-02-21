using DevFreela.Application.Commands.InsertProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class InsertProjectCommandValidator : AbstractValidator<InsertProjectCommand>
    {
        public InsertProjectCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                    .WithMessage("Title can't be empty")
                .MaximumLength(50)
                    .WithMessage("Maximum size of 50 characters exceeded");

            RuleFor(p => p.TotalCost)
                .GreaterThanOrEqualTo(1000)
                    .WithMessage("Project has to cost minimum R$ 1.000");
        }        
    }
}