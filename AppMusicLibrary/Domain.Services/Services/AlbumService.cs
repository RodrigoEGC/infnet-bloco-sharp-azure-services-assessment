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
        private readonly IBlobService _blob;
        private readonly IQueueMessage _queue;

        public AlbumService(
            IAlbumRepository albumRepository,
            IBlobService blobService,
            IQueueMessage queueMessage)
        {
            _repository = albumRepository;
            _blob = blobService;
            _queue = queueMessage;
        }
        public async Task DeleteAsync(AlbumEntity albumEntity)
        {
            await _blob.DeleteAsync(albumEntity.ImageUri);

            var email = new
            {
                Assunto = $"Exclusão de um album {albumEntity.Nome}",
                Corpo = $"Um album seu foi excluído. O nome do seu album excluído é: {albumEntity.Nome}",
                EmailPara = "rodrigo.araujo@infnet.edu.br"
            };
            var jsonEmail = JsonConvert.SerializeObject(email);
            var bytesJsonEmail = UTF8Encoding.UTF8.GetBytes(jsonEmail);
            string jsonEmailBase64 = Convert.ToBase64String(bytesJsonEmail);

            await _queue.SendAsync(jsonEmailBase64);

            await _repository.DeleteAsync(albumEntity);
        }

        public async Task<IEnumerable<AlbumEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AlbumEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task InsertAsync(AlbumEntity albumEntity, Stream stream)
        {
            var newUri = await _blob.UploadAsync(stream);
            albumEntity.ImageUri = newUri;
            await _repository.InsertAsync(albumEntity);
        }

        public async Task UpdateAsync(AlbumEntity albumEntity, Stream stream)
        {
            if (stream != null)
            {
                await _blob.DeleteAsync(albumEntity.ImageUri);

                var newUri = await _blob.UploadAsync(stream);
                albumEntity.ImageUri = newUri;
            }

            await _repository.UpdateAsync(albumEntity);
        }
    }
}
