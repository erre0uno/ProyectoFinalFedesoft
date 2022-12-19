using FluentValidation;
using Mundial.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mundial.Utils
{
    public class TarjetaRojaValidationDTO: AbstractValidator<TarjetaRojaDTO>
    {
        /// <summary>
        /// Constructor de las validaciones de TarjetaRoja
        /// </summary>
        public TarjetaRojaValidationDTO()
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
