using FluentValidation;
using LibreriaApp2026.Servicios.DTOs.Libro;

namespace LibreriaApp2026.Servicios.Validators.Libro
{
    public class LibroUpdateDtoValidator : LibroBaseValidator<LibroUpdateDto>
    {
        public LibroUpdateDtoValidator()
        {
            RuleFor(l => l.Id)
                .GreaterThan(0).WithMessage("El ID del libro es inválido.");
        }
    }
}
