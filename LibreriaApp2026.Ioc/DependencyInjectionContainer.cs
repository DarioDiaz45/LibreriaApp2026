using FluentValidation;
using LibreriaApp2026.Datos;
using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Datos.Repositorios;
using LibreriaApp2026.Servicios.DTOs.Editorial;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Servicios;
using LibreriaApp2026.Servicios.Validators.Editorial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibreriaApp2026.Ioc
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

           
            services.AddDbContext<LibreriaDbContext>();

           
            services.AddScoped<IEditorialRepositorio, EditorialRepositorio>();
            services.AddScoped<IEditorialServicio, EditorialServicio>();
            services.AddScoped<IValidator<EditorialCreateDto>, EditorialCreateDtoValidator>();
            services.AddScoped<IValidator<EditorialUpdateDto>, EditorialUpdateDtoValidator>();

           
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;


        }
    }
}
