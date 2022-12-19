namespace Mundial.DAL.DTO
{
    public class GoleadorDTO
    {
        public int Id { get; set; }
        public int? Goles { get; set; }
        public int? JugadorId { get; set; }
        public string NombreJugador { get; set; }
    }
}
