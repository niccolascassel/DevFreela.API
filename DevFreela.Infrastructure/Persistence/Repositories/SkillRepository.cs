using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly string connectionString;

        public SkillRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                string query = "SELECT Id, Description FROM Skills";

                var skills = await sqlConnection.QueryAsync<Skill>(query);

                if (skills != null)
                    return skills.ToList();

                return new List<Skill>();
            }
        }
    }
}
