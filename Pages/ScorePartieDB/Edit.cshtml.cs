using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Memory.Models;

namespace Memory.Pages.ScorePartieDB
{
    public class EditModel : PageModel
    {
        private readonly Memory.Models.MemoryContext _context;

        public EditModel(Memory.Models.MemoryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ScorePartie ScorePartie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScorePartie = await _context.ScorePartie.FirstOrDefaultAsync(m => m.ID == id);

            if (ScorePartie == null)
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

            _context.Attach(ScorePartie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScorePartieExists(ScorePartie.ID))
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

        private bool ScorePartieExists(int id)
        {
            return _context.ScorePartie.Any(e => e.ID == id);
        }
    }
}
