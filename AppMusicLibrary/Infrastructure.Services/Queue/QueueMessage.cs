using Azure.Storage.Queues;
using Domain.Model.Interfaces.Infrastructure;
using System.Threading.Tasks;

namespace Infrastructure.Services.Queue
{
    public class QueueMessage : IQueueMessage
    {
        private readonly QueueServiceClient _queueServiceClient;
        private const string _queueName = "queue-image-insert";

        public QueueMessage(string storageAccount)
        {
            _queueServiceClient = new QueueServiceClient(storageAccount);
        }
        public async Task SendAsync(string messageText)
        {
            var queueClient = _queueServiceClient.GetQueueClient(_queueName);

            await queueClient.CreateIfNotExistsAsync();

            await queueClient.SendMessageAsync(messageText);
        }
    }
}
