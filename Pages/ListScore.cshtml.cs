using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Memory.Models;
using Memory.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Memory.Pages
{
    public class ListScoreModel : PageModel
    {
        public IList<Partie> Parties;
        public Partie PartieDelete;
        private readonly MemoryContext _context;
        public ListScoreModel(MemoryContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Parties = await _context.Partie.Where(s => s.StateGame == StateGame.DONE.ToString()).OrderByDescending(m => m.CreateAt).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int? PartieId)
        {

            PartieDelete = await _context.Partie.FindAsync(PartieId);

            if (PartieDelete != null)
            {
                _context.Partie.Remove(PartieDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./listScore");
        }

        public ScorePartie this[int id]
        {
            get
            {
                var scorePartie = from m in _context.ScorePartie select m;
                scorePartie = scorePartie.Where(s => s.PartieId == id);
                ScorePartie ScorePartie = scorePartie.Single();
                return ScorePartie; 
            }
 
        }
    }
}