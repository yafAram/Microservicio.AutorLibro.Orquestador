using AutoMapper;
using AutorLibro.Application.DTOs;
using AutorLibro.Domain.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutorLibro.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AutorLibros, AutorLibrosDto>();
            CreateMap<GradoAcademico, GradoAcademicoDto>();
        }
    }
}