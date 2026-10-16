using FluentValidation;
using LibreriaApp2026.Servicios.DTOs.Editorial;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaApp2026.Servicios.Validators.Editorial
{
    public class EditorialUpdateDtoValidator : AbstractValidator<EditorialUpdateDto>
    {
        public EditorialUpdateDtoValidator()
        {
            RuleFor(e => e.Id)
                .GreaterThan(0).WithMessage("El ID de la editorial es inválido.");

            RuleFor(e => e.Nombre)
                .NotEmpty().WithMessage("El nombre de la editorial es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(e => e.PaisOrigen)
                .NotEmpty().WithMessage("El país de origen es obligatorio.")
                .MaximumLength(50).WithMessage("El país no puede superar los 50 caracteres.");
        }
    }
}
