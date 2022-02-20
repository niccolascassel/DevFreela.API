using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces;
using DevFreela.Infrastructure.Persistence.EntityFramework.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext dbContext;
        private readonly string connectionString;

        public ProjectRepository(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.connectionString = configuration.GetConnectionString("DevFreelaCs");
        }        

        public async Task<List<Project>> GetAllAsync()
        {
            return await dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            var project = 
                await dbContext.Projects
                    .Include(p => p.Client)
                    .Include(p => p.Freelancer)
                    .SingleOrDefaultAsync(p => p.Id == id);

            return project;
        }

        public async Task AddAsync(Project project)
        {
            await dbContext.Projects.AddAsync(project);
            await dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Project project)
        {
            project.Cancel();
            await dbContext.SaveChangesAsync();
        }

        public async Task StartAsync(Project project)
        {
            using (var sqlconnection = new SqlConnection(connectionString))
            {
                sqlconnection.Open();

                string query = "UPDATE Projects SET Status = @status, StartedAt = @startedat WHERE Id = @id";
                await sqlconnection.ExecuteAsync(query, new { status = project.Status, startedat = project.StartedAt, project.Id });
            }
        }

        public async Task FinishAsync(Project project)
        {
            using (var sqlconnection = new SqlConnection(connectionString))
            {
                sqlconnection.Open();

                string query = "UPDATE Projects SET Status = @status, FinishedAt = @finishedat WHERE Id = @id";
                await sqlconnection.ExecuteAsync(query, new { status = project.Status, finishedat = project.FinishedAt, project.Id });
            }
        }

        public async Task AddCommentAsync(ProjectComment comment)
        {
            await dbContext.ProjectComments.AddAsync(comment);
            await dbContext.SaveChangesAsync();
        }
    }
}
