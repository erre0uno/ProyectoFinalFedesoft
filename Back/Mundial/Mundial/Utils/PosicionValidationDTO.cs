namespace Mundial.Utils
{
    using FluentValidation;
    using Mundial.DAL.DTO;

    public class PosicionValidationDTO : AbstractValidator<PosicionDTO>
    {
        /// <summary>
        /// Constructor de las validaciones de posicion
        /// </summary>
        public PosicionValidationDTO()
        {
            RuleFor(s => s.Nombre)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Ingrese posición")
                .MaximumLength(30)
                .WithMessage("Excede los 30 caracteres");
        }
    }
}
