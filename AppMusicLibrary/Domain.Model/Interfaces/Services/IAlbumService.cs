using Domain.Model.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumEntity>> GetAllAsync();
        Task<AlbumEntity> GetByIdAsync(int id);
        Task InsertAsync(AlbumEntity albumEntity, Stream stream);
        Task UpdateAsync(AlbumEntity albumEntity, Stream stream);
        Task DeleteAsync(AlbumEntity albumEntity);
    }
}
