using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Memory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Memory.Pages
{
    public class MainGameModel : PageModel
    {
        public Partie Partie { get; set; }
        public ScorePartie ScorePartie { get; set; }
        public IList<Carte> Carte { get; set; }
        public string NameCard;
        public int id { get; set; }
        private readonly MemoryContext _context;

        public MainGameModel(MemoryContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(int id)
        {
            if (id != null && Carte!=null)
            {
            }
            int PartieID = 21;
            Partie = await _context.Partie.FirstOrDefaultAsync(m => m.ID == PartieID);
            ScorePartie = await _context.ScorePartie.FirstOrDefaultAsync(m => m.PartieId == PartieID);
            Carte = await _context.Carte.Where(m => m.PartieId == PartieID).ToListAsync();
        }

  
        public async Task OnGetPartieInfo(int PartieId)
        {
           int a= PartieId;
           
        }
    }
}