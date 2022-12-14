using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProject
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectDetailsViewModel>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetProjectQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects
               .Include(p => p.Client)
               .Include(p => p.Freelancer)
               .SingleOrDefault(p => p.Id == request.Id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.StartedAt,
                project.FinishedAt,
                project.TotalCost,
                project.Client.FullName,
                project.Freelancer.FullName);

            return projectDetailsViewModel;
        }
    }
}
