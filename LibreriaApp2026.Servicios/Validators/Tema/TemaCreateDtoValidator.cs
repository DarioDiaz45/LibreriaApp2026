using FluentValidation;
using LibreriaApp2026.Servicios.DTOs.Tema;

namespace LibreriaApp2026.Servicios.Validators.Tema
{
    public class TemaCreateDtoValidator : AbstractValidator<TemaCreateDto>
    {
        public TemaCreateDtoValidator()
        {
            RuleFor(t => t.Nombre)
                .NotEmpty().WithMessage("El nombre del tema es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(t => t.Descripcion)
                .MaximumLength(255).WithMessage("La descripción no puede superar los 255 caracteres.");
        }
    }
}
