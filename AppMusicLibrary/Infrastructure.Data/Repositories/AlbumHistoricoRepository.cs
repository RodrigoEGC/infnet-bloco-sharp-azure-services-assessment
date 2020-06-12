using Domain.Model.Entities;
using Domain.Model.Interfaces.Repositories;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class AlbumHistoricoRepository : IAlbumHistoricoRepository
    {
        private readonly CloudStorageAccount _cloudStorageAccount;
        private const string _table = "BibliotecaMusical";

        public AlbumHistoricoRepository(string storageAccount)
        {
            _cloudStorageAccount = CloudStorageAccount.Parse(storageAccount);
        }

        public async Task<IEnumerable<AlbumHistoricoEntity>> GetByPartitionKeyAsync(string partitionKey)
        {
            CloudTableClient tableClient = _cloudStorageAccount.CreateCloudTableClient(new TableClientConfiguration());

            CloudTable table = tableClient.GetTableReference(_table);

            var linqQuery = table.CreateQuery<AlbumHistoricoEntity>().Where(x => x.PartitionKey == partitionKey);
            return await Task.Run(() => linqQuery.ToList());
        }

        public async Task InsertAsync(AlbumHistoricoEntity albumHistoricoEntity)
        {
            CloudTableClient tableClient = _cloudStorageAccount.CreateCloudTableClient(new TableClientConfiguration());

            CloudTable table = tableClient.GetTableReference(_table);

            table.CreateIfNotExists();

            var insertOperation = TableOperation.Insert(albumHistoricoEntity);

            _ = await table.ExecuteAsync(insertOperation);
        }

        public async Task UpdateAsync(AlbumHistoricoEntity albumHistoricoEntity)
        {
            CloudTableClient tableClient = _cloudStorageAccount.CreateCloudTableClient(new TableClientConfiguration());

            CloudTable table = tableClient.GetTableReference(_table);

            var updateOperation = TableOperation.InsertOrReplace(albumHistoricoEntity);

            _ = await table.ExecuteAsync(updateOperation);
        }

        public async Task DeleteAsync(AlbumHistoricoEntity albumHistoricoEntity)
        {
            CloudTableClient tableClient = _cloudStorageAccount.CreateCloudTableClient(new TableClientConfiguration());

            CloudTable table = tableClient.GetTableReference(_table);

            var deleteOperation = TableOperation.Delete(albumHistoricoEntity);

            _ = await table.ExecuteAsync(deleteOperation);
        }
    }
}
