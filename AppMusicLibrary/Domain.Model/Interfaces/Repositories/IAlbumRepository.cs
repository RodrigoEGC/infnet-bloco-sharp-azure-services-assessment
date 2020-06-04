using Domain.Model.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Repositories
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<AlbumEntity>> GetAllAsync();
        Task<AlbumEntity> GetByIdAsync(int id);
        Task InsertAsync(AlbumEntity albumEntity);
        Task UpdateAsync(AlbumEntity albumEntity);
        Task DeleteAsync(AlbumEntity albumEntity);
    }
}
