using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Traslado_Seguro.Data;
using Traslado_Seguro.Model;

namespace Traslado_Seguro.Pages.STransportes
{
    public class EditModel : PageModel
    {
        private readonly TrasladoSeguroContext _context;

        public EditModel(TrasladoSeguroContext context)
        {
            _context = context;
        }


        [BindProperty]

        public STransporte Transporte { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Transportes == null)
            {
                return NotFound();
            }

            var transporte = await _context.Transportes.FirstOrDefaultAsync(m => m.Id == id);

            if (transporte == null)
            {
                return NotFound();
            }
            Transporte = transporte;
            return Page();


        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Transporte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!TransporteExists(Transporte.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TransporteExists(int id)
        {

            return (_context.Transportes?.Any(e => e.Id == id)).GetValueOrDefault();

        }
    }
}
