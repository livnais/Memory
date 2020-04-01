using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Memory.Models;

namespace Memory.Pages.PartieDB
{
    public class DetailsModel : PageModel
    {
        private readonly Memory.Models.MemoryContext _context;

        public DetailsModel(Memory.Models.MemoryContext context)
        {
            _context = context;
        }

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
    }
}
