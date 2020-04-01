using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Memory.Models;

namespace Memory.Pages.ScorePartieDB
{
    public class DetailsModel : PageModel
    {
        private readonly Memory.Models.MemoryContext _context;

        public DetailsModel(Memory.Models.MemoryContext context)
        {
            _context = context;
        }

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
    }
}
