using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model.Entities
{
    [Table("BibliotecaMusical")]
    public class AlbumEntity
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        public bool Remasterizado { get; set; }

        [DisplayName("Capa")]
        public string ImageUri { get; set; }
    }
}
