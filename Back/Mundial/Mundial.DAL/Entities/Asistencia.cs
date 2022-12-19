namespace Mundial.DAL.Entities
{
    public partial class Asistencia
    {
        public int Id { get; set; }
        public int? Asistencias { get; set; }
        public int? JugadorId { get; set; }

        public virtual Jugador Jugador { get; set; }
    }
}
