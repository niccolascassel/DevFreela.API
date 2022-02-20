namespace DevFreela.Application.IntegrationEvents
{
    public class ApprovedPaymentIntegrationEvent
    {
        public ApprovedPaymentIntegrationEvent(int projectId)
        {
            ProjectId = projectId;
        }

        public int ProjectId { get; set; }
    }
}
