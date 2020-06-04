using Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class BibliotecaMusicalContext : DbContext
    {
        public BibliotecaMusicalContext (DbContextOptions<BibliotecaMusicalContext> options)
            : base(options)
        {

        }
        public DbSet<AlbumEntity> Albuns { get; set; }
    }
}
