namespace Mundial.DAL.Entities
{
    using System.Collections.Generic;
    public partial class Equipo
    {
        public Equipo()
        {
            Jugador = new HashSet<Jugador>();
            Resultado = new HashSet<Resultado>();
            TablaPosiciones = new HashSet<TablaPosiciones>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? Participaciones { get; set; }
        public string Grupo { get; set; }

        public virtual ICollection<Jugador> Jugador { get; set; }
        public virtual ICollection<Resultado> Resultado { get; set; }
        public virtual ICollection<TablaPosiciones> TablaPosiciones { get; set; }
    }
}
