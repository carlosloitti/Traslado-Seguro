using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Traslado_Seguro.Data;
using Traslado_Seguro.Model;

namespace Traslado_Seguro.Pages.STransportes
{
    public class CreateModel : PageModel
    {
        private readonly TrasladoSeguroContext _context;

        public CreateModel(TrasladoSeguroContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]

        public STransporte Transporte { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Transportes == null || Transporte == null)
            {
                return Page();
            }

            _context.Transportes.Add(Transporte);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
