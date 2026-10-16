using FluentValidation;
using LibreriaApp2026.Servicios.DTOs.Editorial;

namespace LibreriaApp2026.Servicios.Validators.Editorial
{
    public class EditorialCreateDtoValidator : AbstractValidator<EditorialCreateDto>
    {
        public EditorialCreateDtoValidator()
        {
            RuleFor(e => e.Nombre)
                .NotEmpty().WithMessage("El nombre de la editorial es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(e => e.PaisOrigen)
                .NotEmpty().WithMessage("El país de origen es obligatorio.")
                .MaximumLength(50).WithMessage("El país no puede superar los 50 caracteres.");
        }
    }
}
