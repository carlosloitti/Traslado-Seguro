using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Traslado_Seguro.Model
{
    public class STransporte
    {
        public int Id { get; set; }
        
        public string Fecha { get; set; }

        public string NomConductor { get; set; }

        public string NomCliente { get; set; }

        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; } = default!;
    }
}
