namespace Mundial.Utils
{
    using FluentValidation;
    using Mundial.DAL.Entities;

    public class EquipoValidation : AbstractValidator<Equipo>
    {
        /// <summary>
        /// Constructor de las validaciones de Equipo
        /// </summary>
        public EquipoValidation()
        {
            RuleFor(s => s.Nombre)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(30)
                .WithMessage("Por favor escriba el Nombre del Equipo.")
                .MinimumLength(2)
                .WithMessage("Son mínimo 2 caracteres.");

            RuleFor(s => s.Participaciones)
                .NotEmpty()
                .WithMessage("No puede estar vacio.");
            
            RuleFor(s => s.Grupo)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("Es un dato necesario.")
                .MaximumLength(1)
                .WithMessage("Excede el numero de caracteres");
        }
    }
}
