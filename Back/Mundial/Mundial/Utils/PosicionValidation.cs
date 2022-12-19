namespace Mundial.Utils
{
    using FluentValidation;
    using Mundial.DAL.Entities;

    public class PosicionValidation : AbstractValidator<Posicion>
    {
        /// <summary>
        /// Constructor de las validaciones de posicion
        /// </summary>
        public PosicionValidation()
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
