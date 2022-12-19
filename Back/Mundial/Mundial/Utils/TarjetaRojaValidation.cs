namespace Mundial.Utils
{
    using FluentValidation;
    using Mundial.DAL.Entities;

    public class TarjetaRojaValidation: AbstractValidator<TarjetaRoja>
    {
        /// <summary>
        /// Constructor de las validaciones de TarjetaRoja
        /// </summary>
        public TarjetaRojaValidation()
        {
            RuleFor(s => s.Numero)
                .NotEmpty()
                .WithMessage("Ingrese Numero de tarjeta roja");

            RuleFor(s => s.JugadorId)
                .NotEmpty()
                .WithMessage("Ingrese el id del Jugador");
        }
    }
}
