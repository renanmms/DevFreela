using DevFreela.Application.ViewModels;
using DevFreela.Core.DTOs;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkills
{

    public class GetAllSkillsQuery : IRequest<List<SkillDTO>>
    {
    }
}
