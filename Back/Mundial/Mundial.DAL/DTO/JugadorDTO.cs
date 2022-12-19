
namespace Mundial.DAL.DTO
{
    using System;
    public class JugadorDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public decimal? Estatura { get; set; }
        public int? PosicionId { get; set; }
        public string NombrePosicion { get; set; }
        public int? EquipoId { get; set; }
        public string NombreEquipo { get; set; }
    }
}
