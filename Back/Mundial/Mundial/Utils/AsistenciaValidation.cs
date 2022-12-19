namespace Mundial.Utils
{
    using FluentValidation;
    using Mundial.DAL.Entities;

    public class AsistenciaValidation:  AbstractValidator<Asistencia>
    {
        /// <summary>
        /// Constructor de las validaciones de Asistencia
        /// </summary>
        public AsistenciaValidation() 
        {
            RuleFor(s => s.Asistencias).NotEmpty()
                .WithMessage("Goles a favor no puede ser vacio");

            RuleFor(s => s.JugadorId).NotEmpty()
                .WithMessage("Goles en contra no puede ser vacio");

        }
    }
}