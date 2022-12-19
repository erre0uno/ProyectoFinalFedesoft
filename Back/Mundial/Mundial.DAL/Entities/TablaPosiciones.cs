namespace Mundial.DAL.Entities
{
    public partial class TablaPosiciones
    {
        public int Id { get; set; }
        public int? Pj { get; set; }
        public int? Pg { get; set; }
        public int? Pe { get; set; }
        public int? Pp { get; set; }
        public int? Gf { get; set; }
        public int? Gc { get; set; }
        public int? Puntos { get; set; }
        public int? EquipoId { get; set; }

        public virtual Equipo Equipo { get; set; }
    }
}
