using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Traslado_Seguro.Data;
using Traslado_Seguro.Model;

namespace Traslado_Seguro.Pages.STransportes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TrasladoSeguroContext _context;

        public IndexModel(TrasladoSeguroContext context)
        {
            _context = context;
        }

        public IList<STransporte> Transportes { get; set; } = default!;



        public async Task OnGetAsync()
        {
            if (_context.Transportes != null)
            {
                Transportes = await _context.Transportes.ToListAsync();
            }

        }
    }
}
