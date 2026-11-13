using FluentValidation;
using LibreriaApp2026.Datos;
using LibreriaApp2026.Datos.Interfaces;
using LibreriaApp2026.Datos.Repositorios;
using LibreriaApp2026.Servicios.DTOs.Autor;
using LibreriaApp2026.Servicios.DTOs.Cliente;
using LibreriaApp2026.Servicios.DTOs.Editorial;
using LibreriaApp2026.Servicios.DTOs.FormaDePago;
using LibreriaApp2026.Servicios.DTOs.Libro;
using LibreriaApp2026.Servicios.DTOs.Tema;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Servicios.Servicios;
using LibreriaApp2026.Servicios.Validators.Autor;
using LibreriaApp2026.Servicios.Validators.Cliente;
using LibreriaApp2026.Servicios.Validators.Editorial;
using LibreriaApp2026.Servicios.Validators.FormaDePago;
using LibreriaApp2026.Servicios.Validators.Libro;
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

            //LIBRO
            services.AddScoped<ILibroRepositorio, LibroRepositorio>();
            services.AddScoped<ILibroServicio, LibroServicio>();
            services.AddScoped<IValidator<LibroCreateDto>, LibroCreateDtoValidator>();
            services.AddScoped<IValidator<LibroUpdateDto>, LibroUpdateDtoValidator>();
            //VENTAS
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IFormaDePagoRepositorio, FormaDePagoRepositorio>();
            services.AddScoped<IVentaRepositorio, VentaRepositorio>();
            services.AddScoped<IVentaServicio, VentaServicio>();

            //CLIENTE
            services.AddScoped<IClienteServicio, ClienteServicio>();
            services.AddScoped<IValidator<ClienteCreateDto>, ClienteCreateDtoValidator>();
            services.AddScoped<IValidator<ClienteUpdateDto>, ClienteUpdateDtoValidator>();

            //FORMA DE PAGO
            services.AddScoped<IFormaDePagoServicio, FormaDePagoServicio>();
            services.AddScoped<IValidator<FormaDePagoCreateDto>, FormaDePagoCreateDtoValidator>();
            services.AddScoped<IValidator<FormaDePagoUpdateDto>, FormaDePagoUpdateDtoValidator>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;


        }
    }
}
