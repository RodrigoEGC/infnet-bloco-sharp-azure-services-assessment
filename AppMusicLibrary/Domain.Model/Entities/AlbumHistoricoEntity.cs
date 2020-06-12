using Microsoft.Azure.Cosmos.Table;
using System;

namespace Domain.Model.Entities
{
    public class AlbumHistoricoEntity : TableEntity
    {
        public AlbumHistoricoEntity()
        {

        }
        public AlbumHistoricoEntity(AlbumEntity albumEntity, string partition)
        { 

            PartitionKey = partition;
            RowKey = Guid.NewGuid().ToString();
            Nome = albumEntity.Nome;
            DataLancamento = albumEntity.DataLancamento;
            Remasterizado = albumEntity.Remasterizado;
        }

        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public bool Remasterizado { get; set; }
    }
}
