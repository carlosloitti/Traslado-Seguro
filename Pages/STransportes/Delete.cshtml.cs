using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Traslado_Seguro.Data;
using Traslado_Seguro.Model;

namespace Traslado_Seguro.Pages.STransportes
{
    public class DeleteModel : PageModel
    {
        private readonly TrasladoSeguroContext _context;

        public DeleteModel(TrasladoSeguroContext context)
        {
            _context = context;
        }


        [BindProperty]

        public STransporte Transporte { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Transportes == null)
            {
                return NotFound();
            }

            var transporte = await _context.Transportes.FindAsync(id);

            if (transporte != null)
            {
                Transporte = transporte;
                _context.Transportes.Remove(transporte);
                await _context.SaveChangesAsync();
            }


            return RedirectToPage("./Index");
        }
    }
}
