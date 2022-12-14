using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDetailsViewModel>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetUserQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDetailsViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == request.Id);
            var userDetails = new UserDetailsViewModel(request.FullName, request.Email);

            return userDetails;
        }
    }
}
