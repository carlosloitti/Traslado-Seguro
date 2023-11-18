namespace Traslado_Seguro.Model
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public ICollection<STransporte> STransportes { get; set; }
    }
}