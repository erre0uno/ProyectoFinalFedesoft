using FluentValidation;
using Mundial.DAL.DTO;

namespace Mundial.Utils
{
    public class UsuarioValidationDTO : AbstractValidator<UsuarioDTO>
    {
        /// <summary>
        /// Constructor de las validaciones de Usuario
        /// </summary>
        public UsuarioValidationDTO()
        {
            RuleFor(s => s.Nombre)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Ingrese nombre de usuario")
                .MaximumLength(30)
                .WithMessage("Excede los 30 caracteres");

                RuleFor(s => s.Clave)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("campo clave requerido");

                RuleFor(s => s.Tipo)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("campo tipo requerido");
        }
    }
}
