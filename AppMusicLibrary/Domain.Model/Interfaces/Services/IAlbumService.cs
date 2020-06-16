using Domain.Model.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumHistoricoEntity>> GetLogsAsync(string pesquisa);
        Task<IEnumerable<AlbumEntity>> GetAllAsync();
        Task<AlbumEntity> GetByIdAsync(int id);
        Task InsertAsync(AlbumEntity albumEntity);
        Task UpdateAsync(AlbumEntity albumEntity);
        Task DeleteAsync(AlbumEntity albumEntity);
    }
}
