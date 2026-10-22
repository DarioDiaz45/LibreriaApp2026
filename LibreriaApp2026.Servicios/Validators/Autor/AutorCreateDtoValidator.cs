using FluentValidation;
using LibreriaApp2026.Servicios.DTOs.Autor;

namespace LibreriaApp2026.Servicios.Validators.Autor
{
    public class AutorCreateDtoValidator : AbstractValidator<AutorCreateDto>
    {
        public AutorCreateDtoValidator()
        {
            RuleFor(a => a.Nombre)
                .NotEmpty().WithMessage("El nombre del autor es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(a => a.Apellido)
                .NotEmpty().WithMessage("El apellido del autor es obligatorio.")
                .MaximumLength(100).WithMessage("El apellido no puede superar los 100 caracteres.");

            RuleFor(a => a.Nacionalidad)
                .NotEmpty().WithMessage("La nacionalidad es obligatoria.")
                .MaximumLength(50).WithMessage("La nacionalidad no puede superar los 50 caracteres.");

            RuleFor(a => a.FechaNacimiento)
                .LessThanOrEqualTo(_ => DateTime.Today)
                .WithMessage("La fecha de nacimiento no puede ser una fecha futura.");
        }

    }
}
