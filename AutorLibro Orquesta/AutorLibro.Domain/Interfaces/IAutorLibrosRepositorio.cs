using AutorLibro.Domain.Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutorLibro.Domain.Interfaces
{
    public interface IAutorLibrosRepositorio
    {
        Task AddAsync(AutorLibros autor);
        Task<List<AutorLibros>> GetAllWithGradosAsync();
        Task<AutorLibros> GetByIdWithGradosAsync(int id);
    }
}