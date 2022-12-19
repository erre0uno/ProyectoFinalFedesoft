namespace Mundial.Utils
{
    using FluentValidation;
    using Mundial.DAL.Entities;

    public class GoleadorValidation: AbstractValidator<Goleador>
    {
        /// <summary>
        ///Constructor de las validaciones de Goleador 
        /// </summary>
        public GoleadorValidation()
        {
            RuleFor(s => s.Goles).NotEmpty()
                .WithMessage("Ingrese Numero de Goles");

            RuleFor(s => s.JugadorId).NotEmpty()
                .WithMessage("Ingrese el id del Jugador");
        }
    }
}
