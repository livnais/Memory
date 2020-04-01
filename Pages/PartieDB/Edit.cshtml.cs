using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Memory.Models;

namespace Memory.Pages.PartieDB
{
    public class EditModel : PageModel
    {
        private readonly Memory.Models.MemoryContext _context;

        public EditModel(Memory.Models.MemoryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Partie Partie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Partie = await _context.Partie.FirstOrDefaultAsync(m => m.ID == id);

            if (Partie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Partie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartieExists(Partie.ID))
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

        private bool PartieExists(int id)
        {
            return _context.Partie.Any(e => e.ID == id);
        }
    }
}
