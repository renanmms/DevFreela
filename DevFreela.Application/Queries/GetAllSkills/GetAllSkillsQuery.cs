using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public record GetAllSkillsQuery() : IRequest<ResultViewModel<List<Skill>>>;
}