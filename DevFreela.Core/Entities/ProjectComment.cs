namespace DevFreela.Core.Entities
{
    public class ProjectComment : BaseEntity
    {
        public ProjectComment(string content, int projectId, int userId)
        {
            Content = content;
            ProjectId = projectId;
            UserId = userId;
            CreatedAt = DateTime.Now;
        }

        public string Content { get; private set; }
        public int ProjectId { get; private set; }
        public Project Project { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
