using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.InsertUserSkills
{
    public record InsertUserSkillsCommand(int[] SkillIds, int Id)
     : IRequest<ResultViewModel>;
}