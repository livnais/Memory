﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Memory.Models;

namespace Memory.Pages.ScorePartieDB
{
    public class CreateModel : PageModel
    {
        private readonly Memory.Models.MemoryContext _context;

        public CreateModel(Memory.Models.MemoryContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ScorePartie ScorePartie { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ScorePartie.Add(ScorePartie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}