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
    public class IndexModel : PageModel
    {
        private readonly Memory.Models.MemoryContext _context;

        public IndexModel(Memory.Models.MemoryContext context)
        {
            _context = context;
        }

        public IList<ScorePartie> ScorePartie { get;set; }

        public async Task OnGetAsync()
        {
            ScorePartie = await _context.ScorePartie.ToListAsync();
        }
    }
}
