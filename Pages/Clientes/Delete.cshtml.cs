using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Traslado_Seguro.Data;
using Traslado_Seguro.Model;

namespace Traslado_Seguro.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly TrasladoSeguroContext _context;

        public DeleteModel(TrasladoSeguroContext context)
        {
            _context = context;
        }


        [BindProperty]

        public Cliente Cliente { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente != null)
            {
                Cliente = cliente;
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }


            return RedirectToPage("./Index");
        }
    }
}
