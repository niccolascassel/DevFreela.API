using DevFreela.Application.IntegrationEvents;
using DevFreela.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DevFreela.Application.Consumers
{
    public class ApprovedPaymentsConsumer : BackgroundService
    {
        private const string APPROVED_PAYMENTS = "ApprovedPayments";
        private readonly IConnection connection;
        private readonly IModel channel;
        private readonly IServiceProvider serviceProvider;

        public ApprovedPaymentsConsumer(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;

            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: APPROVED_PAYMENTS,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, eventArgs) =>
            {
                var byteArray = eventArgs.Body.ToArray();
                var paymentInfoJson = Encoding.UTF8.GetString(byteArray);

                var paymentInfo = JsonSerializer.Deserialize<ApprovedPaymentIntegrationEvent>(paymentInfoJson);

                FinishProject(paymentInfo.ProjectId);

                channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            channel.BasicConsume(APPROVED_PAYMENTS, false, consumer);

            return Task.CompletedTask;
        }

        private async Task FinishProject(int projectId)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var projectRepository = scope.ServiceProvider.GetRequiredService<IProjectRepository>();

                var project = await projectRepository.GetByIdAsync(projectId);

                project.Finish();

                await projectRepository.SaveChangesAsync();
            }
        }
    }
}
