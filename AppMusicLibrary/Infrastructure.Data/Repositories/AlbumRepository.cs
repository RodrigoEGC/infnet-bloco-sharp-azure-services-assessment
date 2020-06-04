using Domain.Model.Entities;
using Domain.Model.Interfaces.Repositories;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly BibliotecaMusicalContext _context;

        public AlbumRepository(BibliotecaMusicalContext bibliotecaMusicalContext)
        {
            _context = bibliotecaMusicalContext;
        }

        public async Task DeleteAsync(AlbumEntity albumEntity)
        {
            _context.Remove(albumEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AlbumEntity>> GetAllAsync()
        {
            return await _context.Albuns.ToListAsync();
        }

        public async Task<AlbumEntity> GetByIdAsync(int id)
        {
            return await _context.Albuns.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(AlbumEntity albumEntity)
        {
            _context.Add(albumEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AlbumEntity albumEntity)
        {
            _context.Update(albumEntity);
            await _context.SaveChangesAsync();
        }
    }
}
