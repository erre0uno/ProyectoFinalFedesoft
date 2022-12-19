namespace Mundial.DAL.Entities
{
    public partial class Resultado
    {
        public int Id { get; set; }
        public int? Gf { get; set; }
        public int? Gc { get; set; }
        public int? NumeroPartido { get; set; }
        public int? EquipoId { get; set; }

        public virtual Equipo Equipo { get; set; }
    }
}
