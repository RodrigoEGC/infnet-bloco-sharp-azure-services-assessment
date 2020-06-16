using Azure.Storage.Queues;
using Domain.Model.Entities;
using Domain.Model.Interfaces.Infrastructure;
using System.Threading.Tasks;

namespace Infrastructure.Services.Queue
{
    public class QueueMessage : IQueueMessage
    {
        private readonly QueueServiceClient _queueServiceClient;
        private const string _queueInsert = "queue-image-insert";
        private const string _queueDelete = "queue-image-delete";

        public QueueMessage(string storageAccount)
        {
            _queueServiceClient = new QueueServiceClient(storageAccount);
        }
        public async Task SendAsync(string messageText)
        {
            var queueClient = _queueServiceClient.GetQueueClient(_queueInsert);

            await queueClient.CreateIfNotExistsAsync();

            await queueClient.SendMessageAsync(messageText);
        }

        public async Task DeleteAsync(string messageText)
        {
            var queueClient = _queueServiceClient.GetQueueClient(_queueDelete);

            await queueClient.CreateIfNotExistsAsync();

            await queueClient.SendMessageAsync(messageText);
        }
    }
}
