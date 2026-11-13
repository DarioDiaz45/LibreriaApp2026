using FluentValidation;
using LibreriaApp2026.Servicios.DTOs.FormaDePago;

namespace LibreriaApp2026.Servicios.Validators.FormaDePago
{
    public class FormaDePagoCreateDtoValidator : AbstractValidator<FormaDePagoCreateDto>
    {
        public FormaDePagoCreateDtoValidator()
        {
            RuleFor(f => f.Nombre)
                .NotEmpty().WithMessage("El nombre de la forma de pago es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");
        }
    }
}
