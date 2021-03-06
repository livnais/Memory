﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Memory.Models;

namespace Memory.Pages.PartieDB
{
    public class IndexModel : PageModel
    {
        private readonly Memory.Models.MemoryContext _context;

        public IndexModel(Memory.Models.MemoryContext context)
        {
            _context = context;
        }

        public IList<Partie> Partie { get;set; }

        public async Task OnGetAsync()
        {
            Partie = await _context.Partie.ToListAsync();
        }
    }
}
