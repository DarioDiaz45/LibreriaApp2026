using FluentValidation;
using LibreriaApp2026.Datos;
using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Datos.Repositorios;
using LibreriaApp2026.Servicios.DTOs.Autor;
using LibreriaApp2026.Servicios.DTOs.Editorial;
using LibreriaApp2026.Servicios.DTOs.Tema;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Servicios;
using LibreriaApp2026.Servicios.Validators.Autor;
using LibreriaApp2026.Servicios.Validators.Editorial;
using LibreriaApp2026.Servicios.Validators.Tema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibreriaApp2026.Ioc
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {


            services.AddDbContext<LibreriaDbContext>();

            //EDITORIAL
            services.AddScoped<IEditorialRepositorio, EditorialRepositorio>();
            services.AddScoped<IEditorialServicio, EditorialServicio>();
            services.AddScoped<IValidator<EditorialCreateDto>, EditorialCreateDtoValidator>();
            services.AddScoped<IValidator<EditorialUpdateDto>, EditorialUpdateDtoValidator>();

            //AUTOR
            services.AddScoped<IAutorRepositorio, AutorRepositorio>();
            services.AddScoped<IAutorServicio, AutorServicio>();
            services.AddScoped<IValidator<AutorCreateDto>, AutorCreateDtoValidator>();
            services.AddScoped<IValidator<AutorUpdateDto>, AutorUpdateDtoValidator>();


            //TEMA
            services.AddScoped<ITemaRepositorio, TemaRepositorio>();
            services.AddScoped<ITemaServicio, TemaServicio>();
            services.AddScoped<IValidator<TemaCreateDto>, TemaCreateDtoValidator>();
            services.AddScoped<IValidator<TemaUpdateDto>, TemaUpdateDtoValidator>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;


        }
    }
}
