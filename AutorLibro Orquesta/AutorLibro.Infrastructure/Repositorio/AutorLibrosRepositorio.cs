using AutorLibro.Domain.Interfaces;
using AutorLibro.Domain.Modelos;
using AutorLibro.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace AutorLibro.Infrastructure.Repositorio
{
    public class AutorLibrosRepositorio : IAutorLibrosRepositorio
    {
        private readonly AutorLibrosContext _context;

        public AutorLibrosRepositorio(AutorLibrosContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AutorLibros autor)
        {
            _context.AutorLibros.Add(autor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AutorLibros>> GetAllWithGradosAsync()
        {
            return await _context.AutorLibros
                .Include(a => a.GradoAcademico)
                .ToListAsync();
        }

        public async Task<AutorLibros> GetByIdWithGradosAsync(int id)
        {
            return await _context.AutorLibros
                .Include(a => a.GradoAcademico)
                .FirstOrDefaultAsync(a => a.AutorLibroId == id);
        }
    }
}