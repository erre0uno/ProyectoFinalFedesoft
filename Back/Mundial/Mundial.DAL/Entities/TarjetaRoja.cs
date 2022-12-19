namespace Mundial.DAL.Entities
{
    public partial class TarjetaRoja
    {
        public int Id { get; set; }
        public int? Numero { get; set; }
        public int? JugadorId { get; set; }

        public virtual Jugador Jugador { get; set; }
    }
}
