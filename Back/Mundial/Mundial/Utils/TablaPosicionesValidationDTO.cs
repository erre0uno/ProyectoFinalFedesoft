namespace Mundial.Utils
{
    using FluentValidation;
    using Mundial.DAL.DTO;


    public class TablaPosicionesValidationDTO : AbstractValidator<TablaPosicionesDTO>
    {
        /// <summary>
        /// Constructor de las validaciones de tabla de posiciones
        /// </summary>
        public TablaPosicionesValidationDTO()
        {

            RuleFor(s => s.Pj)
                .NotEmpty()
                .WithMessage("Ingrese el numero de partidos jugados");
            
            RuleFor(s => s.Pe)
                .NotEmpty()
                .WithMessage("Ingrese el numero de partidos empatados");
            
            RuleFor(s => s.Pp)
                .NotEmpty()
                .WithMessage("Ingrese el numero de partidos perdidos");
            
            RuleFor(s => s.Gf)
                .NotEmpty()
                .WithMessage("Ingrese el numero de goles a favor");
            
            RuleFor(s => s.Gc)
                .NotEmpty()
                .WithMessage("Ingrese el numero de goles en contra");
            
            RuleFor(s => s.Puntos)
                .NotEmpty()
                .WithMessage("Ingrese el numero de puntos");
            
            RuleFor(s => s.EquipoId)
                .NotEmpty()
                .WithMessage("Ingrese el id del equipo");
            
            RuleFor(s => s.Pg)
                .NotEmpty()
                .WithMessage("Ingrese el numero de partidos ganados");
        }
    }
}
