namespace Mundial.Utils
{
    using FluentValidation;
    using Mundial.DAL.DTO;

    public class JugadorValidationDTO : AbstractValidator<JugadorDTO>
    {
        /// <summary>
        /// Constructor de las validaciones de Jugador
        /// </summary>
        public JugadorValidationDTO()
        {
            RuleFor(s => s.Nombre)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Ingrese nombre jugador")
                .MaximumLength(30)
                .WithMessage("Excede los 30 caracteres");

            RuleFor(s => s.Apellidos)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Ingrese apellido jugador")
                .MaximumLength(30)
                .WithMessage("Excede los 30 caracteres");

            RuleFor(s => s.PosicionId).NotEmpty()
                .WithMessage("Ingrese id posición");

            RuleFor(s => s.FechaNacimiento).NotEmpty()
                .WithMessage("Ingrese fecha nacimiento jugador");

            RuleFor(s => s.Estatura).ScalePrecision(3, 2);

            RuleFor(s => s.EquipoId).NotEmpty()
                .WithMessage("Ingrese id equipo");

        }
    }
}
