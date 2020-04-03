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
    public class ListPartieModel : PageModel
    {
        private readonly MemoryContext _context;
        public ListPartieModel(MemoryContext context)
        {
            _context = context;
        }

        public IList<Partie> Partie { get; set; }
        public Partie PartieDelete { get; set; }
    


        public async Task OnGetAsync()
        {
            Partie = await _context.Partie.Where(m => m.StateGame == StateGame.INPROGRESS.ToString()).OrderByDescending(m=>m.CreateAt).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int? PartieId,int actionType)
        {
            if (PartieId == null)
            {
                return NotFound();
            }
            if (actionType == 1)
            {
                return RedirectToPage("./mainGame", "GameInfo", new { PartieId });
            }
            else if (actionType == 0)
            {
                PartieDelete = await _context.Partie.FindAsync(PartieId);
              
                if (PartieDelete != null )
                {
                   
                    _context.Partie.Remove(PartieDelete);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("./listPartie");
        }
    }
}