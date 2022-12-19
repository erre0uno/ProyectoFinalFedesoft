namespace Mundial.DAL.Entities
{
    using System.Collections.Generic;
    public partial class Posicion
    {
        public Posicion()
        {
            Jugador = new HashSet<Jugador>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Jugador> Jugador { get; set; }
    }
}
