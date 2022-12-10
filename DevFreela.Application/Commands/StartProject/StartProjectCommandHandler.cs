using Dapper;
using DevFreela.Core.Enums;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, ProjectStatusEnum>
    {
        private readonly DevFreelaDbContext _dbContext;
        private readonly string _connectionString;

        public StartProjectCommandHandler(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<ProjectStatusEnum> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);
            project.Start();
            //_dbContext.SaveChanges();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = @"UPDATE 
                                    Projects
                               SET
                                    Status = @status,
                                    StartedAt = @startedAt
                               WHERE
                                    Id = @id";

                await sqlConnection.ExecuteAsync(script,
                    new
                    {
                        status = project.Status,
                        startedat = project.StartedAt,
                        request.Id
                    });
            }

            return project.Status;
        }
    }
}
