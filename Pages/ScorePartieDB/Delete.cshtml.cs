﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Memory.Models;

namespace Memory.Pages.ScorePartieDB
{
    public class DeleteModel : PageModel
    {
        private readonly Memory.Models.MemoryContext _context;

        public DeleteModel(Memory.Models.MemoryContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScorePartie = await _context.ScorePartie.FindAsync(id);

            if (ScorePartie != null)
            {
                _context.ScorePartie.Remove(ScorePartie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
