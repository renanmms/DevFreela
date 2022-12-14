using DevFreela.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProject
{
    public class GetProjectQuery : IRequest<ProjectDetailsViewModel>
    {
        public int Id { get; private set; }
        public string ClientFullName { get; private set; }
        public string FreelancerFullName { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public decimal TotalCost { get; private set; }
    }
}
