namespace Mundial.Utils
{
    using FluentValidation;
    using Mundial.DAL.DTO;

    public class GoleadorValidationDTO: AbstractValidator<GoleadorDTO>
    {
        /// <summary>
        ///Constructor de las validaciones de Goleador 
        /// </summary>
        public GoleadorValidationDTO()
        {
            RuleFor(s => s.Goles).NotEmpty()
                .WithMessage("Ingrese Numero de Goles");

            RuleFor(s => s.JugadorId).NotEmpty()
                .WithMessage("Ingrese el id del Jugador");
        }
    }
}
