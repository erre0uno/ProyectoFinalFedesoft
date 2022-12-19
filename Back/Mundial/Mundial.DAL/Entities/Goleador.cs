namespace Mundial.DAL.Entities
{
    public partial class Goleador
    {
        public int Id { get; set; }
        public int? Goles { get; set; }
        public int? JugadorId { get; set; }

        public virtual Jugador Jugador { get; set; }
    }
}
