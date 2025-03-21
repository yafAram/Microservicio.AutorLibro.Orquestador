using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutorLibro.Application;
using AutorLibro.Application.Comandos;
using AutorLibro.Application.Orchestration;
using AutorLibro.Domain.Interfaces;
using AutorLibro.Infrastructure.Persistencia;
using AutorLibro.Infrastructure.Repositorio;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutorLibro.Infrastructure.Extensiones
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Base de datos
            services.AddDbContext<AutorLibrosContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Repositorio
            services.AddScoped<IAutorLibrosRepositorio, AutorLibrosRepositorio>();

            // Orchestrator
            services.AddScoped<AutorLibrosOrchestrator>();

            // AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            // MediatR
            services.AddMediatR(typeof(Nuevo.Manejador).Assembly);


            // CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            return services;
        }
    }
}
