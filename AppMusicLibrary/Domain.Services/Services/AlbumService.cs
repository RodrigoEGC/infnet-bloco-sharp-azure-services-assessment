using Domain.Model.Entities;
using Domain.Model.Interfaces.Infrastructure;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _repository;
        private readonly IQueueMessage _queue;
        private readonly IAlbumHistoricoRepository _historicoRepository;

        public AlbumService(
            IAlbumRepository albumRepository,
            IQueueMessage queueMessage,
            IAlbumHistoricoRepository albumHistoricoRepository)
        {
            _repository = albumRepository;
            _queue = queueMessage;
            _historicoRepository = albumHistoricoRepository;
        }
        public async Task<IEnumerable<AlbumHistoricoEntity>> GetLogsAsync(string pesquisa)
        {
            return await _historicoRepository.GetByPartitionKeyAsync(pesquisa);
        }
        public async Task DeleteAsync(AlbumEntity albumEntity)
        {
            await _repository.DeleteAsync(albumEntity);

            var partitionName = "delete";

            await _historicoRepository.InsertAsync(new AlbumHistoricoEntity(albumEntity, partitionName));
        }

        public async Task<IEnumerable<AlbumEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AlbumEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task InsertAsync(AlbumEntity albumEntity)
        {
            await _repository.InsertAsync(albumEntity);

            var message = new
            {
                ImageUri = albumEntity.ImageUri,
                Id = $"{albumEntity.Id}",
            };

            var jsonMessage = JsonConvert.SerializeObject(message);
            var bytesJsonMessage = UTF8Encoding.UTF8.GetBytes(jsonMessage);
            string jsonMessageBase64 = Convert.ToBase64String(bytesJsonMessage);

            await _queue.SendAsync(jsonMessageBase64);

            var partitionName = "insert";

            await _historicoRepository.InsertAsync(new AlbumHistoricoEntity(albumEntity, partitionName));
        }

        public async Task UpdateAsync(AlbumEntity albumEntity)
        {
            await _repository.UpdateAsync(albumEntity);

            var parttionName = "update";

            await _historicoRepository.UpdateAsync(new AlbumHistoricoEntity(albumEntity, parttionName));
        }
    }
}
