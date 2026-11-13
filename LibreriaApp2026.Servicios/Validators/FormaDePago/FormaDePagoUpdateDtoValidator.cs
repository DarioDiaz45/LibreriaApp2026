using FluentValidation;
using LibreriaApp2026.Servicios.DTOs.FormaDePago;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaApp2026.Servicios.Validators.FormaDePago
{
    public class FormaDePagoUpdateDtoValidator : AbstractValidator<FormaDePagoUpdateDto>
    {
        public FormaDePagoUpdateDtoValidator()
        {
            RuleFor(f => f.FormaDePagoId)
                .GreaterThan(0).WithMessage("El ID de la forma de pago es inválido.");

            RuleFor(f => f.Nombre)
                .NotEmpty().WithMessage("El nombre de la forma de pago es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");
        }
    }
}
