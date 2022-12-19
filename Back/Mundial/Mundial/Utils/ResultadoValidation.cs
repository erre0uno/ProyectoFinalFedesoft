
namespace Mundial.Utils
{
    using FluentValidation;
    using Mundial.DAL.Entities;

    public class ResultadoValidation: AbstractValidator<Resultado>
    {
        /// <summary>
        /// Constructor de las validaciones de Resultados
        /// </summary>
        public ResultadoValidation() 
        {

            RuleFor(s => s.Gf).NotEmpty()
                .WithMessage("Goles a favor no puedde ser vacio");

            RuleFor(s => s.Gc).NotEmpty()
                .WithMessage("Goles en contra no puedde ser vacio");

            RuleFor(s => s.NumeroPartido).NotEmpty()
                .WithMessage("Numero de Partidos no puede ser vacio");

            RuleFor(s => s.EquipoId).NotEmpty()
                .WithMessage("Id del Equipo no puede ser vacio");

        }

    }
}
