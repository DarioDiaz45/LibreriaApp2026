using FluentValidation;
using LibreriaApp2026.Servicios.DTOs.Libro;

namespace LibreriaApp2026.Servicios.Validators.Libro
{
    public abstract class LibroBaseValidator<T> : AbstractValidator<T> where T : LibroCreateDto
    {
        protected LibroBaseValidator()
        {
            RuleFor(l => l.Titulo)
                .NotEmpty().WithMessage("El título es obligatorio.")
                .MaximumLength(200).WithMessage("El título no puede superar los 200 caracteres.");

            RuleFor(l => l.Descripcion)
                .MaximumLength(500).WithMessage("La descripción no puede superar los 500 caracteres.");

            RuleFor(l => l.AnioPublicacion)
                .InclusiveBetween(1000, DateTime.Today.Year)
                .WithMessage($"El año de publicación debe estar entre 1000 y {DateTime.Today.Year}.");

            RuleFor(l => l.Precio)
                .GreaterThanOrEqualTo(0).WithMessage("El precio no puede ser negativo.");

            RuleFor(l => l.EditorialId)
                .GreaterThan(0).WithMessage("Debe seleccionar una editorial.");

            RuleFor(l => l.AutoresIds)
                .NotEmpty().WithMessage("El libro debe tener al menos un autor.");

            RuleFor(l => l.TemasIds)
                .NotEmpty().WithMessage("El libro debe tener al menos un tema.");

            // Libro físico
            When(l => l.Tipo == TipoLibro.Fisico, () =>
            {
                RuleFor(l => l.ISBN)
                    .NotEmpty().WithMessage("El ISBN es obligatorio.")
                    .MaximumLength(20).WithMessage("El ISBN no puede superar los 20 caracteres.");

                RuleFor(l => l.Stock)
                    .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");
            });

            // Libro digital
            When(l => l.Tipo == TipoLibro.Digital, () =>
            {
                RuleFor(l => l.Identificador)
                    .NotEmpty().WithMessage("El identificador es obligatorio.")
                    .MaximumLength(50).WithMessage("El identificador no puede superar los 50 caracteres.");

                RuleFor(l => l.Formato)
                    .NotEmpty().WithMessage("El formato es obligatorio.")
                    .MaximumLength(20).WithMessage("El formato no puede superar los 20 caracteres.");

                RuleFor(l => l.TamanoArchivo)
                    .GreaterThan(0).WithMessage("El tamaño del archivo debe ser mayor a cero.");

                RuleFor(l => l.UrlDescarga)
                    .NotEmpty().WithMessage("La URL de descarga es obligatoria.")
                    .MaximumLength(500).WithMessage("La URL no puede superar los 500 caracteres.");
            });
        }
    }
}
