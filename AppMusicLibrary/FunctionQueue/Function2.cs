using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
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
            using var webClient = new WebClient();
            byte[] imageBytes = webClient.DownloadData(message.ImageUri.ToString());

            var blobAtributte = new BlobAttribute($"imagens/{Guid.NewGuid()}.jpg", FileAccess.Write);
            var cloudBlobStream = await binder.BindAsync<ICloudBlob>(blobAtributte);
            await cloudBlobStream.UploadFromByteArrayAsync(imageBytes, 0, imageBytes.Length);
            await cloudBlobStream.Container.SetPermissionsAsync(new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Blob });

            var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var textSql = $@"DELETE [dbo].[BibliotecaMusical] SET [ImageUri] = '{cloudBlobStream.Uri}' WHERE Id = {message.Id}";

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
