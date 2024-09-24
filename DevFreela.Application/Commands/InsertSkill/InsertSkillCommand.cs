using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.InsertSkill
{
    public record InsertSkillCommand(string Description) : IRequest<ResultViewModel<int>>;
}