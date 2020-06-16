using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace FunctionQueue
{
    public static class Function2
    {
        [FunctionName("Function2")]
        public async static Task Run([QueueTrigger("queue-image-delete")]
            MessageImage message,
            IBinder binder,
            ILogger log)
        {
            log.LogInformation($"Função ativada!");
            var blobAtributte = new BlobAttribute(message.ImageUri, FileAccess.Read);
            var cloudBlobStream = await binder.BindAsync<ICloudBlob>(blobAtributte);
            await cloudBlobStream.DeleteIfExistsAsync();
            await cloudBlobStream.Container.SetPermissionsAsync(new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Blob });

            var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var textSql = $@"DELETE FROM [dbo].[BibliotecaMusical] WHERE Id = {message.Id}";

                using (SqlCommand cmd = new SqlCommand(textSql, conn))
                {
                    var rowsAffected = cmd.ExecuteNonQuery();
                    log.LogInformation($"rowsAffected: {rowsAffected}");
                }
            }

            log.LogInformation($"Função encerrada!");
        }
        public class MessageImage
        {
            public string ImageUri { get; set; }
            public string Id { get; set; }
        }
    }
}
