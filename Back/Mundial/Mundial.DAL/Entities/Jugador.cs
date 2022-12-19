namespace Mundial.DAL.Entities
{
    using System;
    using System.Collections.Generic;

    public partial class Jugador
    {
        public Jugador()
        {
            Asistencia = new HashSet<Asistencia>();
            Goleador = new HashSet<Goleador>();
            TarjetaRoja = new HashSet<TarjetaRoja>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public decimal? Estatura { get; set; }
        public int? PosicionId { get; set; }
        public int? EquipoId { get; set; }

        public virtual Equipo Equipo { get; set; }
        public virtual Posicion Posicion { get; set; }
        public virtual ICollection<Asistencia> Asistencia { get; set; }
        public virtual ICollection<Goleador> Goleador { get; set; }
        public virtual ICollection<TarjetaRoja> TarjetaRoja { get; set; }
    }
}
