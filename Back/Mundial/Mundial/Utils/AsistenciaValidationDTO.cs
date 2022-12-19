namespace Mundial.Utils
{
    using FluentValidation;
    using Mundial.DAL.DTO;

    public class AsistenciaValidationDTO:  AbstractValidator<AsistenciaDTO>
    {
        /// <summary>
        /// Constructor de las validaciones de Asistencia
        /// </summary>
        public AsistenciaValidationDTO() 
        {
            RuleFor(s => s.Asistencias).NotEmpty()
                .WithMessage("Goles a favor no puedde ser vacio");

            RuleFor(s => s.JugadorId).NotEmpty()
                .WithMessage("Goles en contra no puedde ser vacio");

        }
    }
}