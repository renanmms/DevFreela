using Dapper;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly string _connectionString;

        public SkillRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<SkillDTO>> GetAll()
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();

                var script = @"SELECT Id, Description FROM Skills";
                var query = await dbConnection.QueryAsync<SkillDTO>(script);

                return query.ToList();
            }
        }
    }
}
