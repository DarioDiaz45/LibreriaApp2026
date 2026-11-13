using FluentValidation;
using LibreriaApp2026.Servicios.DTOs.Cliente;

namespace LibreriaApp2026.Servicios.Validators.Cliente
{
    public class ClienteCreateDtoValidator : AbstractValidator<ClienteCreateDto>
    {
        public ClienteCreateDtoValidator()
        {
            RuleFor(c => c.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(c => c.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres.");

            RuleFor(c => c.Telefono)
                .MaximumLength(30).WithMessage("El teléfono no puede superar los 30 caracteres.");

            RuleFor(c => c.Email)
                .MaximumLength(100).WithMessage("El email no puede superar los 100 caracteres.")
                .EmailAddress().WithMessage("El formato del email no es válido.")
                .When(c => !string.IsNullOrWhiteSpace(c.Email));
        }
    }
}
