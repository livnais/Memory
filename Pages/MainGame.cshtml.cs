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
        public int idCard1 { get; set; }
        public int idCard2 { get; set; }
        private readonly MemoryContext _context;

        public MainGameModel(MemoryContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(int id,int idCardSelected1)
        {
         
            if (id != 0)
            {
                idCard1 = id;
            }
            if (idCardSelected1 != 0)
            {
                idCard2 = idCardSelected1;
            }
            if (idCard1 != 0 && idCard2 != 0)
            {
                //System.Threading.Thread.Sleep(3000);
                //idCard1 = 0;
                //idCard2 = 0;
            }
            int PartieId = int.Parse(Request.Cookies["PartieId"]);
            Partie = await _context.Partie.FirstOrDefaultAsync(m => m.ID == PartieId);
            ScorePartie = await _context.ScorePartie.FirstOrDefaultAsync(m => m.PartieId == PartieId);
            Carte = await _context.Carte.Where(m => m.PartieId == PartieId).ToListAsync();
           
        }
        public ActionResult MyNextAction()
        {
            return Page();
        }

        public async Task<IActionResult> OnGetGameInfo(int PartieId)
        {
     
            Partie = await _context.Partie.FirstOrDefaultAsync(m => m.ID == PartieId);
            ScorePartie = await _context.ScorePartie.FirstOrDefaultAsync(m => m.PartieId == PartieId);
            Carte = await _context.Carte.Where(m => m.PartieId == PartieId).ToListAsync();
            if(Partie==null && ScorePartie==null && Carte.Count == 0)
            {
                return RedirectToPage("./index");
            }
            Response.Cookies.Append("PartieId", PartieId.ToString());

            return Page();
        }

    }
}