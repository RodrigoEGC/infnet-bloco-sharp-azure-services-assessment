using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Interfaces.Repositories
{
    public interface IAlbumHistoricoRepository
    {
        Task<IEnumerable<AlbumHistoricoEntity>> GetByPartitionKeyAsync(string partitionKey);

        Task InsertAsync(AlbumHistoricoEntity albumHistoricoEntity);

        Task UpdateAsync(AlbumHistoricoEntity albumHistoricoEntity);

        Task DeleteAsync(AlbumHistoricoEntity albumHistoricoEntity);
    }
}
